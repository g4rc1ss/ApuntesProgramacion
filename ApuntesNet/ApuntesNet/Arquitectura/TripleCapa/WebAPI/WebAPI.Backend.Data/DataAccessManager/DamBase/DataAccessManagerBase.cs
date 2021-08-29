namespace WebAPI.Backend.Data.DataAccessManager.DamBase {
    public abstract class DataAccessManagerBase {
        protected readonly WebApiPruebaContext webApiPruebaContext;

        protected DataAccessManagerBase(WebApiPruebaContext webApiPruebaContext) {
            this.webApiPruebaContext = webApiPruebaContext;
        }
    }
}
