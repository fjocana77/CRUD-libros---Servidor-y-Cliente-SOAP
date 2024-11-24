from zeep import Client
from zeep.transports import Transport
import requests
import warnings
from requests.packages.urllib3.exceptions import InsecureRequestWarning

# Suprimir las advertencias de verificación SSL
warnings.simplefilter('ignore', InsecureRequestWarning)

# URL del WSDL del servicio SOAP
wsdl_url = 'https://localhost:44300/LibraryService.asmx?WSDL'

# Crear una sesión y desactivar la verificación de certificados SSL (útil para desarrollo)
session = requests.Session()
session.verify = False  # Desactiva la verificación SSL
transport = Transport(session=session)

# Crear el cliente SOAP usando el WSDL
client = Client(wsdl=wsdl_url, transport=transport)

# Ejemplo de llamada a un método del servicio SOAP (GetBooks)
try:
    response = client.service.GetBooks()  # Llamada al método
    print(response)  # Imprimir la respuesta
except Exception as e:
    print(f"Error al llamar al servicio: {e}")
