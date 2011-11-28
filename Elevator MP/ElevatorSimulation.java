public class ElevatorSimulation

{
	public static void main(java.lang.String[] args)
	{
		System.out.println("Simulation begins ...");
		Elevator elevator = new Elevator((byte) 1);
		System.out.println("Elevator Number is: " + elevator.getIdentifier());
	}
}