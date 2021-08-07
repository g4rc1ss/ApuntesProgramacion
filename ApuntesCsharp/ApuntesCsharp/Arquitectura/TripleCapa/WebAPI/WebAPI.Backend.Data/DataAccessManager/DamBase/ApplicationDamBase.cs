namespace WebAPI.Backend.Data.DataAccessManager.DamBase {
    public abstract class ApplicationDamBase {
        protected readonly WebApiPruebaContext webApiPruebaContext;

        protected ApplicationDamBase(WebApiPruebaContext webApiPruebaContext) {
            this.webApiPruebaContext = webApiPruebaContext;
        }
    }
}
