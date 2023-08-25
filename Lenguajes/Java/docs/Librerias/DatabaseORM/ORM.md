# Configuración de Hibernate
Agrega la biblioteca Hibernate a tu proyecto (por ejemplo, a través de Maven o Gradle). Crea un archivo de configuración `hibernate.cfg.xml` para establecer la conexión a la base de datos y otras configuraciones.

```xml
<!DOCTYPE hibernate-configuration PUBLIC "-//Hibernate/Hibernate Configuration DTD 3.0//EN"
"http://hibernate.sourceforge.net/hibernate-configuration-3.0.dtd">
<hibernate-configuration>
    <session-factory>
        <property name="hibernate.dialect">org.hibernate.dialect.MySQLDialect</property>
        <property name="hibernate.connection.url">jdbc:mysql://localhost:3306/nombre_base_de_datos</property>
        <property name="hibernate.connection.username">usuario</property>
        <property name="hibernate.connection.password">contraseña</property>
        <!-- Otras propiedades de configuración -->
    </session-factory>
</hibernate-configuration>
```

# Definición de Clases de Entidad
Crea clases Java que representen las entidades en tu base de datos. Anota estas clases con anotaciones de Hibernate para establecer la relación entre las clases y las tablas en la base de datos.

```java
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

@Entity
public class Producto {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String nombre;
    private double precio;

    // Getters y setters
}
```

# Operaciones CRUD con Hibernate
Utiliza sesiones de Hibernate para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la base de datos.

```java
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

public class OperacionesCRUD {
    public static void main(String[] args) {
        SessionFactory sessionFactory = new Configuration().configure("hibernate.cfg.xml").buildSessionFactory();
        try (Session session = sessionFactory.openSession()) {
            Transaction transaction = session.beginTransaction();

            // Crear un nuevo producto
            Producto producto = new Producto();
            producto.setNombre("Producto A");
            producto.setPrecio(100.0);
            session.save(producto);

            // Leer un producto por su ID
            Producto productoLeido = session.get(Producto.class, 1L);
            System.out.println("Producto leido: " + productoLeido.getNombre());

            // Actualizar un producto
            productoLeido.setPrecio(150.0);
            session.update(productoLeido);

            // Eliminar un producto
            session.delete(productoLeido);

            transaction.commit();
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            sessionFactory.close();
        }
    }
}
```

# Consultas con Hibernate Query Language (HQL)
Hibernate ofrece su propio lenguaje de consulta llamado HQL, que es similar a SQL pero trabaja con objetos en lugar de tablas.

```java
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

import java.util.List;

public class ConsultasHQL {
    public static void main(String[] args) {
        SessionFactory sessionFactory = new Configuration().configure("hibernate.cfg.xml").buildSessionFactory();
        try (Session session = sessionFactory.openSession()) {
            Query query = session.createQuery("FROM Producto WHERE precio > :precio");
            query.setParameter("precio", 100.0);
            List<Producto> productos = query.list();

            for (Producto producto : productos) {
                System.out.println("Producto: " + producto.getNombre());
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            sessionFactory.close();
        }
    }
}
```

# Relaciones entre Entidades
Hibernate permite definir relaciones entre entidades, como relaciones uno a uno, uno a muchos y muchos a muchos, utilizando anotaciones.

```java
import javax.persistence.*;
import java.util.List;

@Entity
public class Cliente {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String nombre;

    @OneToMany(mappedBy = "cliente")
    private List<Pedido> pedidos;

    // Getters y setters
}

@Entity
public class Pedido {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne
    @JoinColumn(name = "cliente_id")
    private Cliente cliente;

    // Getters y setters
}
```

En resumen, ORM (Object-Relational Mapping) en Java permite mapear objetos de una aplicación a entidades en una base de datos relacional. Hibernate es una de las bibliotecas ORM más populares en Java. Permite definir clases de entidad, realizar operaciones CRUD y consultas utilizando sesiones de Hibernate y HQL. También admite relaciones entre entidades. El uso de ORM simplifica la interacción con la base de datos y reduce la necesidad de escribir SQL manualmente.