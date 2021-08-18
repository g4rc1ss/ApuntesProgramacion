public class DemasiadosObjetos extends Exception {
    public DemasiadosObjetos() {
        super();
    }

    @Override
    public String getMessage() {
        return "Se ha alcanzado el número máximo de elementos";
    }
}
