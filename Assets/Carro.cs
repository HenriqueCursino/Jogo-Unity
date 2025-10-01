using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] private WheelCollider rodaTraseiraDireita;
    [SerializeField] private WheelCollider rodaFrenteDireita;
    [SerializeField] private WheelCollider rodaFrenteEsquerda;
    [SerializeField] private WheelCollider rodaTraseiraEsquerda;

    [Header("Configurações do Carro")]
    public float aceleracao = 500f;
    public float freio = 300f;
    public float anguloTorque = 15f;

    private float aceleracaoAtual = 0f;
    private float freioAtual = 0f;
    private float anguloTorqueAtual = 0f;

    private void FixedUpdate()
    {
        // Movimento para frente/trás
        aceleracaoAtual = aceleracao * Input.GetAxis("Vertical");
        rodaFrenteDireita.motorTorque = aceleracaoAtual;
        rodaFrenteEsquerda.motorTorque = aceleracaoAtual;

        // Direção esquerda/direita
        anguloTorqueAtual = anguloTorque * Input.GetAxis("Horizontal");
        rodaFrenteDireita.steerAngle = anguloTorqueAtual;
        rodaFrenteEsquerda.steerAngle = anguloTorqueAtual;

        // Freio (tecla espaço)
        if (Input.GetKey(KeyCode.Space))
        {
            freioAtual = freio;
        }
        else
        {
            freioAtual = 0f;
        }

        rodaFrenteDireita.brakeTorque = freioAtual;
        rodaFrenteEsquerda.brakeTorque = freioAtual;
        rodaTraseiraDireita.brakeTorque = freioAtual;
        rodaTraseiraEsquerda.brakeTorque = freioAtual;
    }
}
