public class Elevator extends java.lang.Object

{
	private final int FIRST_FLOOR = 1;
	private final int SECOND_FLOOR = 2;
	private final int MAX_PASSENGERS = 10;
	private final int MAX_DELAY = 10;
	
	private byte identifier;
	private byte passengerCount = 0;
	private byte currentFloor = 1;
	private byte timeLeftToDeparture = 0;
	private int totalPassengerCount = 0;
	
	public Elevator(byte elevatorNumber)
	{
		this.identifier = elevatorNumber;
		// if (this.currentFloor == FIRST_FLOOR)
		// {
		this.currentFloor = FIRST_FLOOR;
		// }
		// if (this.passengerCount < MAX_PASSENGERS)
		// {
			// this.addPassenger("New Pasahero");
		// }
		
		this.print();
	}
	
	public void print()
	{
		if(this.isElevatorHere(this.currentFloor) && this.passengerCount < MAX_PASSENGERS)
		{
			//System.out.println(" Loaded into elevator: " + this.currentFloor);
		}
		
		else if(!this.isElevatorHere(this.currentFloor))
		{
			System.out.println(" Takes the stairs.");
		}
		
		if(this.isElevatorHere(this.currentFloor) && (this.passengerCount == MAX_PASSENGERS || this.timeLeftToDeparture == MAX_DELAY))
		{
			System.out.println(" Loaded into elevator: " + this.currentFloor + "\nElvator departing from floor " + this.currentFloor + " with " + this.passengerCount + " passengers.\n");
			if (this.currentFloor == FIRST_FLOOR)
			{
				this.currentFloor = SECOND_FLOOR;
			} else {
				this.currentFloor = FIRST_FLOOR;
			}
			this.passengerCount = 0;
			this.timeLeftToDeparture = 0;
		}
	}
	
	public byte getIdentifier()
	{
		return this.identifier;
	}
	
	public void tick()
	{
		//String tick = "tick";
		if (timeLeftToDeparture < MAX_DELAY)
		{
			timeLeftToDeparture++;
		}
		//System.out.println("Tick.");
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
	
	public boolean addPassenger(String newPass)
	{
		passengerCount++;
		return true;
	}
	
	public void reportPassengerCount()
	{
		System.out.println("Total passengers: " + this.totalPassengerCount);
	}
	
	public void printTicks()
	{
		System.out.println("Ticks: " + this.timeLeftToDeparture);
	}
	
	public void elevatorCurrentFloor()
	{
		System.out.println("Elevator is on: " + this.currentFloor);
	}
}