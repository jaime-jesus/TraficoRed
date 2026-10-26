using System.Net.NetworkInformation;

Console.Title = "Monitor de Tráfico de Red en Tiempo Real";
Console.CursorVisible = false;

// 1. Obtener los adaptadores de red activos (Wi-Fi o Ethernet)
var interfaces = NetworkInterface.GetAllNetworkInterfaces()
    .Where(nic => nic.OperationalStatus == OperationalStatus.Up &&
                  nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    .ToList();

if (!interfaces.Any())
{
    Console.WriteLine("❌ No se encontraron conexiones de red activas.");
    return;
}

// Seleccionar la conexión activa principal
var nic = interfaces.First();

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("==========================================================");
Console.WriteLine(" 🌐 MONITOR DE TRÁFICO DE RED EN TIEMPO REAL");
Console.WriteLine($" Adaptador: {nic.Name} ({nic.NetworkInterfaceType})");
Console.WriteLine($" Descripción: {nic.Description}");
Console.WriteLine("==========================================================");
Console.ResetColor();

// Lectura inicial
var statsInicial = nic.GetIPv4Statistics();
long prevBytesRecv = statsInicial.BytesReceived;
long prevBytesSent = statsInicial.BytesSent;

// 2. Bucle infinito para refrescar cada 1 segundo
while (true)
{
    await Task.Delay(1000); // Esperar 1 segundo

    var stats = nic.GetIPv4Statistics();
    long currentBytesRecv = stats.BytesReceived;
    long currentBytesSent = stats.BytesSent;

    // Calcular velocidad por segundo (Bytes/seg -> KB/seg)
    double downloadSpeedKB = (currentBytesRecv - prevBytesRecv) / 1024.0;
    double uploadSpeedKB = (currentBytesSent - prevBytesSent) / 1024.0;

    // Calcular totales acumulados en MB
    double totalRecvMB = currentBytesRecv / (1024.0 * 1024.0);
    double totalSentMB = currentBytesSent / (1024.0 * 1024.0);

    // Actualizar los valores anteriores
    prevBytesRecv = currentBytesRecv;
    prevBytesSent = currentBytesSent;

    // 3. Pintar métricas en la consola
    Console.SetCursorPosition(0, 6);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($" ⬇️  Descarga actual:  {FormatearVelocidad(downloadSpeedKB)}           ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($" ⬆️  Subida actual:    {FormatearVelocidad(uploadSpeedKB)}           ");
    Console.ResetColor();
    Console.WriteLine(" --------------------------------------------------------");
    Console.WriteLine($" 📦 Total descargado:  {totalRecvMB:F2} MB");
    Console.WriteLine($" 📤 Total subido:      {totalSentMB:F2} MB");
    Console.WriteLine(" ========================================================");
    Console.WriteLine(" Presiona Ctrl + C para salir.");
}

// Función auxiliar para mostrar KB/s o MB/s automáticamente
static string FormatearVelocidad(double kbps)
{
    if (kbps >= 1024)
        return $"{kbps / 1024.0:F2} MB/s";
    return $"{kbps:F2} KB/s";
}
