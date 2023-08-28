# Instalación y Configuración
   El primer paso es instalar y configurar la biblioteca ORM de tu elección. Ejemplos populares incluyen Doctrine ORM y Eloquent (utilizado con el framework Laravel).

# Definición de Modelos
   Los modelos representan las entidades o tablas en la base de datos. Debes definir una clase para cada tabla y definir propiedades que representen las columnas de la tabla.

   **Ejemplo con Doctrine ORM:**
   ```php
   use Doctrine\ORM\Mapping as ORM;

   /**
    * @ORM\Entity
    * @ORM\Table(name="usuarios")
    */
   class Usuario {
       /**
        * @ORM\Id
        * @ORM\GeneratedValue
        * @ORM\Column(type="integer")
        */
       protected $id;

       /**
        * @ORM\Column(type="string")
        */
       protected $nombre;

       // Otras propiedades y métodos...
   }
   ```

   **Ejemplo con Eloquent (Laravel):**
   ```php
   use Illuminate\Database\Eloquent\Model;

   class Usuario extends Model {
       protected $table = 'usuarios';
       protected $fillable = ['nombre'];

       // Otras propiedades y métodos...
   }
   ```

# Consultas y Manipulación de Datos
   Con un ORM, puedes realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) de manera más intuitiva utilizando métodos y propiedades en tus modelos.

   **Ejemplo con Doctrine ORM:**
   ```php
   $entityManager = // Obtén la instancia del EntityManager
   $usuario = new Usuario();
   $usuario->setNombre("Juan");
   $entityManager->persist($usuario);
   $entityManager->flush();
   ```

   **Ejemplo con Eloquent (Laravel):**
   ```php
   $usuario = new Usuario();
   $usuario->nombre = "Juan";
   $usuario->save();
   ```

# Consultas Avanzadas
   Los ORMs ofrecen métodos para realizar consultas más complejas y avanzadas utilizando métodos encadenados.

   **Ejemplo con Doctrine ORM:**
   ```php
   $usuarios = $entityManager->getRepository(Usuario::class)->findBy(['nombre' => 'Juan']);
   ```

   **Ejemplo con Eloquent (Laravel):**
   ```php
   $usuarios = Usuario::where('nombre', 'Juan')->get();
   ```

# Relaciones entre Modelos
   Los ORMs también permiten definir relaciones entre modelos, como uno a uno, uno a muchos y muchos a muchos.

   **Ejemplo con Doctrine ORM:**
   ```php
   /**
    * @ORM\OneToMany(targetEntity="Direccion", mappedBy="usuario")
    */
   private $direcciones;
   ```

   **Ejemplo con Eloquent (Laravel):**
   ```php
   public function direcciones() {
       return $this->hasMany(Direccion::class);
   }
   ```
