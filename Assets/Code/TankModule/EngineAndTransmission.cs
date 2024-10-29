using System;
using TMPro;
using UnityEngine;

public class EngineAndTransmission : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public Rigidbody rg;

    [Header("Engine Settings")]
    public float maxRPM = 7000f; // Максимальные обороты двигателя
    
    public float idleRPM = 1000f; // Обороты холостого хода
    public float engineAcceleration = 300f; // Скорость набора оборотов
    public float engineDeceleration = 200f; // Скорость сброса оборотов
    public float maxEngineTorque = 500f; // Максимальный крутящий момент двигателя
    public float breakForce = 100f;

    [Header("Transmission Settings")]
    [Range(0f, 1f)] public float upShiftPercent = 0.9f; //Процент от максимального кол-ва оборотов для повышения передачи
    [Range(0f, 1f)] public float downShiftPercent = 0.5f; //Процент от оборотов холостого хода для понижения передачи
    [Range(0f, 1f)] public float decreaseRmpPercent = 0.7f; //Процент от максимального кол-ва оборотов для повышения передачи
    [Range(0f, 1f)] public float increaseRmpPercent = 0.3f; //Процент от оборотов холостого хода для понижения передачи
    
    public float[] forwardGearRatios; // Передаточные числа каждой передачи
    public float reverseGearRatio = 3.5f; // задняя передача
    public float finalDriveRatio = 3.42f; // Главная передача

    private float currentRPM = 0f; // Текущие обороты двигателя
    private int currentGear = 0; // Текущая передача
    private float currentEngineTorque = 0f; // Текущий крутящий момент двигателя
    private float currentWheelForce;
    private Vector3 previousPosition;
    private Vector3 currentVelocity;

    private void Start()
    {
        if (forwardGearRatios.Length <= 0)
        {
            Debug.LogError("Нужна хотя бы одна передняя передача для работы двигателя");
            return;
        }
    }

    private void Update()
    {
        float gasInput = 0;

        if (Input.GetKey(KeyCode.W))
        {
            gasInput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gasInput = -1;
        }

        var breakInput = Input.GetKey(KeyCode.Space) ? 1 : 0;
        
        UpdateEngineRPM(gasInput, breakInput);
        HandleGearShift();
        
    }

    private void FixedUpdate()
    {
        CalculateWheelForce();
        CalculateCurrentSpeed();
    }

    private void UpdateEngineRPM(float gasInput, float breakInput)
    {
        if (gasInput != 0 && breakInput <= 0) //движение вперёд
        {
            currentRPM += Mathf.Abs(gasInput) * engineAcceleration * Time.deltaTime;
            
            if (currentGear == 0)
            {
                currentGear++;
            }
        }
        else //торможение
        {
            if (breakInput > 0)
            {
                currentRPM -= breakInput * breakForce * engineDeceleration * Time.deltaTime;
            }
            else
            {
                currentRPM -= engineDeceleration * Time.deltaTime;
            }
        }
        
        currentRPM = Mathf.Clamp(currentRPM, idleRPM, maxRPM);
    }

    private void HandleGearShift()
    {
        if (currentRPM > maxRPM * upShiftPercent && currentGear < forwardGearRatios.Length)
        {
            currentGear++;
            currentRPM *= decreaseRmpPercent;
        }
        else if (currentRPM < idleRPM * (downShiftPercent + 1) && currentGear > 1)
        {
            currentGear--;
            currentRPM *= increaseRmpPercent + 1;
        }

        if (currentGear == 1 && Math.Abs(currentRPM - idleRPM) < 0.5f)
        {
            currentGear--;
        }
    }

    private void CalculateWheelForce()
    {
        currentEngineTorque = currentRPM / maxRPM * maxEngineTorque;

        if (currentGear == 0)
        {
            currentWheelForce = 0;
        }
        else
        {
            float totalGearRatio =  forwardGearRatios[currentGear - 1] * finalDriveRatio;
            float wheelTorque = currentEngineTorque / totalGearRatio;

            // Преобразуем крутящий момент в линейную силу, разделил на корректирующее число (в реальности это радиус колеса)
            currentWheelForce = wheelTorque / 5;
        }
        
        rg.MovePosition(transform.position + Vector3.forward * (currentWheelForce * Time.fixedDeltaTime));

        ShowDebugInfo();
    }
    
    private void CalculateCurrentSpeed()
    {
        var position = transform.position;
        
        currentVelocity = (position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = position;
    }
    
    private void ShowDebugInfo()
    {
        var gearInfo = currentGear switch
        {
            0 => "N",
            < 0 => "R",
            _ => currentGear.ToString()
        };

        textInfo.text =
            $"Текущая передача: {gearInfo} \nОбороты: {currentRPM:F0} об/мин \nСила на колеса: {currentWheelForce:F2} Н \nСкорость: {currentVelocity}";
    }
}
