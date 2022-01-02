public class UsoOracle {
    public static void main(String[] args) {
        new Oracle.createTable().createTableExecute();
        new Oracle.InsertInto().insertIntoExecute();
        new Oracle.Select().selectExecute();
        new Oracle.Update().updateExecute();
        new Oracle.Delete().deleteExecute();
    }
}
