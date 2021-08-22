package ORMHibernate._03_Database.Dam.Base;

import org.hibernate.Session;
import org.hibernate.boot.Metadata;
import org.hibernate.boot.MetadataSources;
import org.hibernate.boot.registry.StandardServiceRegistry;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;

public class DataAccessManager {
    protected StandardServiceRegistry registry;

    public DataAccessManager() {

    }

    protected Session getContextFactory() {
        // Create registry
        registry = new StandardServiceRegistryBuilder().configure().build();

        // Create MetadataSources
        MetadataSources sources = new MetadataSources(registry);

        // Create Metadata
        Metadata metadata = sources.getMetadataBuilder().build();

        // Create SessionFactory
        var context = metadata.getSessionFactoryBuilder().build();

        return context.openSession();
    }

    protected void shutdown() {
        if (registry != null) {
            StandardServiceRegistryBuilder.destroy(registry);
        }
    }
}
