using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StandardAssets.GamePlay.Scripts.GamePlay.Infraestructura;
using StandardAssets.GamePlay.Scripts.GamePlay.Proveedor;
using StandardAssets.GamePlay.Scripts.GamePlay.Vistas;

public class AislarModulo : MonoBehaviour
{
    [SerializeField] ConfiguracionGeneral configuracion;
    private static RepositorioConfiguracion repositorioConfiguracion;

    private void Awake()
    {
        repositorioConfiguracion = new RepositorioConfiguracion(configuracion);
        GamePlayProveedor.Iniciliazar(repositorioConfiguracion);
    }
}
