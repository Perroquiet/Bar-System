import java.io.*;

public class ElevatorSimulation

{
	private static final String FILE = "run1.dat";
	
	//Samtang wala pa ang passenger class magbuhat sa tag attributes kunuhay
		private String passengerName;
		private byte floorName;
		
	
	public static void main(java.lang.String[] args)
	{
		try
		{
		String strLine;
		String[] temp;
		String delimiter = " ";
		String tick = "tick";
				
		FileInputStream fstream = new FileInputStream(FILE);
		DataInputStream in = new DataInputStream(fstream);
		BufferedReader br = new BufferedReader(new InputStreamReader(in));
		
		System.out.println("Simulation begins ...\n");
			
		while ((strLine = br.readLine()) != null)
		{
			//System.out.println (strLine);
			if (strLine.equals(tick))
			{
				System.out.println("Tick.");
			}
			else
			{
				temp = strLine.split(delimiter);
			
				// for (int i=0; i<temp.length; i++)
				// {
					System.out.println("Passenger " + temp[1] + " arrives on floor " + temp[2]);
				// }
			}
			
			
		
		}
		
		in.close();
		}
		
		catch (Exception e)
		{
			//Do nothing
			//System.err.println("Error: " + e.getMessage());
		}
		
		
		Elevator elevator = new Elevator((byte) 1);
		//System.out.println("Elevator Number is: " + elevator.getIdentifier());
		System.out.println("\nSimulation complete.");
	}
}