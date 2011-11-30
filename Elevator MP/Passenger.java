public class Passenger extends java.lang.Object

{
	private java.lang.String inName;
	private byte inFloor;

	public Passenger(java.lang.String tempName, byte tempFloor)
	{
		inName = tempName;
		inFloor = tempFloor;
		print();
	}

	public void print()
	{
		System.out.print("Passenger Name: " + this.getName());
		System.out.println(" arrives on floor " + this.getFloor());
	}

	public java.lang.String getName()
	{
		return inName;
	}

	public byte getFloor()
	{
		return inFloor;
	}

}