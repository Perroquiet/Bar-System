public class Elevator extends java.lang.Object

{
	private static final int FIRST_FLOOR = 1;
	private static final int SECOND_FLOOR = 2;
	private static final int MAX_PASSENGERS = 10;
	private static final int MAX_DELAY = 10;
	
	private byte identifier;
	private byte passengerCount;
	private byte currentFloor;
	private byte timeLeftToDeparture;
	private int totalPassengerCount;
	
	public Elevator(byte elevatorNumber)
	{
		identifier = elevatorNumber;
		
	}
	
	// public void print()
	// {
	
	// }
	
	public byte getIdentifier()
	{
		return this.identifier;
	}
	
	// public void tick()
	// {
	
	// }
	
	// public byte getPassengerCount()
	// {
	
	// }
	
	// public boolean isElevatorHere(Passenger newPass)
	// {
	
	// }
	
	// public static boolean addPassenger(Passenger newPass)
	// {
		
	// }
	
	// public void reportPassengerCount()
	// {
	
	// }
}