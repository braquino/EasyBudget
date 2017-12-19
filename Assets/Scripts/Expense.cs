using SQLite4Unity3d;

public class Expense  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Description { get; set; }
	public string Category { get; set; }
	public string Date { get; set; }
	public double Value {get; set;}

	public override string ToString ()
	{
		return string.Format ("{0} | {1} | {2} | {3} | {4:F2}", Id, Description, Category, Date, Value);
	}
}
