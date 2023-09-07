public class Estudiante
{
    private string code;
    private string name;

    private string[] quices = new string[4];
    private string[] trabajos = new string[2];
    private string[] parciales = new string[3];

    public Estudiante()
    {
        // Constructor vacío
    }

    public Estudiante(string code, string name, string[] quices, string[] trabajos, string[] parciales)
    {
        this.code = code;
        this.name = name;
        this.quices = quices;
        this.trabajos = trabajos;
        this.parciales = parciales;
    }

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string[] Quices
    {
        get { return quices; }
        set { quices = value; }
    }

    public string[] Trabajos
    {
        get { return trabajos; }
        set { trabajos = value; }
    }

    public string[] Parciales
    {
        get { return parciales; }
        set { parciales = value; }
    }
}
