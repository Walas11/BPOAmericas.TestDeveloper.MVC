BPOAmericas.TestDeveloper

Prueba técnica de desarrollo. Solución con 3 proyectos: API, Application y MVC.

Cómo correrlo
Abrir la solución en Visual Studio.
Verificar que estén configurados como proyectos de inicio: API y MVC.
Loguearse con las credenciales de prueba (ver abajo).

Credenciales de prueba
Usuario: BPOAmericas@bpoamericas.com
Contraseña: BPOAmericas2026*

Endpoint LoginUser

POST /Security/LoginUser

El usuario y la contraseña van codificados en Base64, no en texto plano.

Ejemplo de request:

json
{
  "userName": "QlBPQW1lcmljYXNAYnBvYW1lcmljYXMuY29t",
  "userPassword": "QlBPQW1lcmljYXMyMDI2Kg==",
  "clientIP": "120.0.0.1",
  "userAgent": "Opera"
}

Esos valores en Base64 corresponden al usuario y contraseña de arriba.

Response (200 OK):

json
{
  "idUser": 5,
  "userName": "TEST USER",
  "userProfile": "lowlevel",
  "lastLoginDate": "2026-09-30T10:15:25"
}

El token JWT viene en el header Authorization de la respuesta, no en el body.

Notas
No se usó base de datos, el usuario está fijo en el código para efectos de la prueba.
Para probar el endpoint protegido en Postman/Swagger, tomar el token del header de la respuesta del login y pegarlo en Authorization → Bearer Token.
