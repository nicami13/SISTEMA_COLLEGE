public class Estudiante
{
    private string code;
    private string name;

    private List<string> quices = new List<string>();
    private List<string> trabajos = new List<string>();
    private List<string> parciales = new List<string>();

    public Estudiante()
    {
        // Constructor vacío
    }

    public Estudiante(string code, string name, List<string> quices, List<string> trabajos, List<string> parciales)
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

    public List<string> Quices
    {
        get { return quices; }
        set { quices = value; }
    }

    public List<string> Trabajos
    {
        get { return trabajos; }
        set { trabajos = value; }
    }

    public List<string> Parciales
    {
        get { return parciales; }
        set { parciales = value; }
    }
}
