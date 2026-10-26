# 🌐 Monitor de Tráfico de Red en Tiempo Real

[![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)](https://docs.microsoft.com/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Herramienta de consola desarrollada en **C# y .NET 8** que monitorea y mide en tiempo real el consumo de ancho de banda y tráfico de red entrante y saliente del equipo.

---

## 🚀 Características

* ⚡ **Medición en tiempo real:** Muestreo y actualización continua cada 1 segundo.
* ⬇️ **Velocidad de Descarga y Subida:** Cálculo dinámico con auto-escala en **KB/s** y **MB/s**.
* 📦 **Total de Datos Transferidos:** Muestra el acumulado total descargado y subido en Megabytes (MB).
* 🔍 **Detección Automática de Interfaz:** Identifica la tarjeta de red activa principal (Wi-Fi o Ethernet).
* 🪶 **Zero Dependencias:** Utiliza las APIs nativas de `System.Net.NetworkInformation` sin librerías externas ni drivers adicionales.

---

## 🛠️ Tecnologías Empleadas

* **Lenguaje:** C# 12
* **Plataforma:** .NET 8 (Consola)
* **Namespace Core:** `System.Net.NetworkInformation`

---

## ▶️ Cómo Ejecutar el Proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/jaime-jesus/TraficoRed.git
   cd TraficoRed
