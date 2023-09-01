using System.Data.SqlClient;

namespace CRUDCORE.Datos

    //instalamos la libreria sqlCliente para utilizar todas sus clases y objetos para poder conectarnos a nuestro SQL
    //(para instalarlo damos click derecho en el proyecto y admin nuget packages y ahi en el buscador lo instalamos)
    
    //para conectarnos a la base de datos en este proyecto se utiliza ADO.NET con el se realizan todas las operaciones
    //no se utiliza entitiframework que es un ORM por ejemplo
{
    //clase para obtener la cadena de conexion
    public class Conexion
    {
        // declaramos una variable vacia para la cadena de conexion
        private string cadenaSQL = string.Empty;

        //constructor (es el primer metodo que se ejecuta cuando utilizamos esta clase de conexion cuando creamos una instancia por ejemplo)
        public Conexion() {

            //utilizamos var en lugar de string para que tome cualquier tipo que detecte en el valor de la variable
            //obtiene la cadina de conexion que esta en el appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //almacenamos el valor de la cadena de conexion definida en el archivo appsettings.json en la variable cadenaSQL
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        //creaciono de metodo que devuelve la cadena sql que obtuvimos en el constructor
        public string getCadenaSQL() {
            return cadenaSQL;
        }


    }
}
