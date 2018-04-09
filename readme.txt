La solución esta divida en 4 proyectos.

DAL (Data Access Layer) contiene los repositorios que se comunican con la base de datos.

POCO(Plain Old CLR Object) contiene los objetos simples utilizados en {a traves de la app}. 

El proyecto de WebApi implementa un RESTful api y utiliza el framework de MVC para servir las vistas correspondientes a las peticiones de cliente.


PolizaTests contiene las clases de pruebas de integración y unitarias para los objetos

Adjuntado cambien viene el backup de la base de datos y el script para poder generarla de la forma que se desee. 
La base de datos viene con algunos records de prueba ya que no se implemento un CRUD de Cliente. 

De lo puntos opcionales no se han realizado los siguientes:

~ Con la implementación de ORM, Si se usa codeFirst, se debe tener definido los
Migrations y Seeding de los datos. Para esta prueba implemente Dapper y no EF.

~ Autenticación y autorización. 
La idea original era implementarlas con tokens utilizando las liberias Owin e Identity 
pero por cuestiones de tiempo se dejo de lado. 


El string de conexión a la base de datos debe de ser cambiado en 2 lugares; 

WepApi -> WebConfig
PolizaTests -> App.config