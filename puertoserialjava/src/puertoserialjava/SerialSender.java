package puertoserialjava;

import com.fazecast.jSerialComm.SerialPort;

public class SerialSender {
    public static void main(String[] args) {
        SerialPort[] ports = SerialPort.getCommPorts();
        if (ports.length == 0) {
            System.out.println("No hay puertos disponibles. Por favor, verifica las conexiones.");
            return;
        }

        System.out.println("Puertos disponibles:");
        for (SerialPort port : ports) {
            System.out.println(port.getSystemPortName());
        }

        //SerialPort comPort = ports[0];
        SerialPort comPort = SerialPort.getCommPort("COM7"); 
        comPort.setBaudRate(9600);
        if (comPort.openPort()) {
            System.out.println("Puerto abierto satisfactoriamente");
        } else {
            System.out.println("No se puede abrir el puerto");
            return;
        }

        try {
            String message = "Mensaje Hola desde Java";
            comPort.getOutputStream().write(message.getBytes());
            comPort.getOutputStream().flush();
            System.out.println("Mensaje Enviado");
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            comPort.closePort();
            System.out.println("Puerto Cerrado");
        }
    }
}