public class Elevator extends java.lang.Object

{
	private static final int FIRST_FLOOR = 1;
	private static final int SECOND_FLOOR = 2;
	private static final int MAX_PASSENGERS = 8;
	private static final int MAX_DELAY = 10;
	
	private byte identifier;
	private byte passengerCount = 0;
	private byte currentFloor = 1;
	private byte timeLeftToDeparture = 0;
	private int totalPassengerCount = 0;
	
	public Elevator(byte elevatorNumber)
	{
		this.identifier = elevatorNumber;
		if (this.currentFloor == FIRST_FLOOR)
		{
			this.currentFloor = elevatorNumber;
		}
		if (this.passengerCount < MAX_PASSENGERS)
		{
			this.addPassenger("New Pasahero");
		}
		this.print();
	}
	
	public void print()
	{
		if(this.isElevatorHere(this.currentFloor) || this.passengerCount == MAX_PASSENGERS || this.timeLeftToDeparture == MAX_DELAY)
		{
			if (this.currentFloor == FIRST_FLOOR)
			{
				this.currentFloor = SECOND_FLOOR;
			} else {
				this.currentFloor = FIRST_FLOOR;
			}
			System.out.println("larga!");
		}
	}
	
	public byte getIdentifier()
	{
		return this.identifier;
	}
	
	public static void tick()
	{
		//String tick = "tick";
		if (this.timeLeftToDeparture < MAX_DELAY)
		{
			this.timeLeftToDeparture++;
		}
		System.out.println("Tick.");
	}
	
	public byte getPassengerCount()
	{
		return this.passengerCount;
	}
	
	public boolean isElevatorHere(byte newPass)
	{
		if (this.currentFloor == newPass)
			return true;
		else
			return false;
	}
	
	public static boolean addPassenger(String newPass)
	{
		this.passengerCount++;
		return true;
	}
	
	public void reportPassengerCount()
	{
		System.out.println("Total passengers: " + this.totalPassengerCount);
	}
}