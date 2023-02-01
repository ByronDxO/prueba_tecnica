## Generación de Token JWT para inicio de sesión 
### Como Utilizar a Través de la Vista 
#### Lo primero con lo que nos encontramos es una pagin con los dos endpoint permitidos en la app uno es eliminación y el otro es login
<p align="center"><img src="./img/img1.png" /></p>

#### Para poder ingresar primero necesitamos posicionarnos en el enpoint requerido en este caso login y presionamos el boton "Try it Out"
<p align="center"><img src="./img/img2.png" /></p>

#### En esta area para ingresar  texto ingresamos nuestras credenciales en formato json
<p align="center"><img src="./img/img3.png" /></p>

#### Al hacerlo de la manera correcta nos mostrar un mensaje de exito y nos generara un token, debemos copiar el token generado
<p align="center"><img src="./img/Img4.png" /></p>

#### No posicionamos en el boton "Authorize"  
<p align="center"><img src="./img/img5.png" /></p>

#### Para que nuestro token tenga validez por cuestiones de librearia deberemos de colocar la palabra "Bearer" y seguido copiar nuestro token  
<p align="center"><img src="./img/img6.png" /></p>

#### Luego de haber colocado Bearer [token] en nuestro campo le damos a authorizar
<p align="center"><img src="./img/img7.png" /></p>

#### esto nos permitira ingresar al endpoint de eliminar y abriremos una sesión en la pagina , estas sesiones tienen una duración de 60 minutos 
<p align="center"><img src="./img/img8.png" /></p>

#### Nos posicionamos en el endpoint de eliminar 
<p align="center"><img src="./img/img9.png" /></p>

#### Presionamos el boton de "try it Out" y luego el de ejecutar esto nos generara un resultado dependiendo de nuestro rol de usuario, como este usuario no tiene los permisos necesarios no nos dejara ejecutar la función
<p align="center"><img src="./img/img10.png" /></p>

#### Probamos con un Usuario que si tiene los permisos necesarios y si la operación ha sido resuelta de manera satisfactoria se mostrara un mensaje de "usuario eliminado"
<p align="center"><img src="./img/img11.png" /></p>
