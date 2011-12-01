/**
 *
 * ElevatorSimulation.java
 *
 * @version   $Id$
 *
 * Revisions:
 *     $Log$
 */

import java.util.*;
import java.io.*;

/**
 * This class provides a testing harness for the virtual elevator system.
 * This class opens a file provided as a command line argument, then 
 * processes an input file to simulate the functions of the elevators.
 *
 * Use the print statement below to format your output for the passenger
 * count.  Refer to the overview document for more information.
 *
 * System.out.println( "Elevator number " + <Display elevator identifier here>
 *     + " passenger count was: " + <Display passenger count here> );
 *
 */

public class ElevatorSimulation{

    private static Elevator elevator1;        // elevator 1
    private static Elevator elevator2;        // elevator 2

    private static StreamTokenizer in;        // Stream from data file

    /**
     * This is the main method for the simulation.  This method runs the
     * simulation.  It expects 1 command line argument which
     * is the input data file name.  It verifies that a
     * file name is provided, then opens the file.  Errors
     * are reported if the command line argument is missing,
     * or if errors are encountered in opening the file.
     *
     * It creates the elevators and starts the simulation.
     *
     */

    public static void main( String args[] ) {

	// Process command line
        boolean okToContinue = true;

        // Ensure correct number of arguments was provided
	if( args.length != 1 ) {
	    System.err.println( "Usage:  java ElevatorSimulation dataFile" );
	    okToContinue = false;
	}

	// Attempt to open the data file and attach a stream tokenizer
	// to it for parsing the input.
        if (okToContinue) {
	    try {
	        in = new StreamTokenizer( 
                         new BufferedReader( new FileReader( args[0] ) ) );
   	    } catch ( Exception e ) {
	        System.err.println( "ElevatorSimulation:  " 
			      + "Unable to open data file" );
	        okToContinue = false;
	    }
        }

	// if no errors detected, create eleavators and run the simulation
	if (okToContinue) {
            // create the elevators
            elevator1 = new Elevator( ( byte ) 1 );
            elevator2 = new Elevator( ( byte ) 2 );

	    runSimulation();
        }
    } //  end main

   /**
     * This method runs the simulation by invoking the
     * processSimulationFile method.
     *
     */

    private static void runSimulation() {
	boolean error = false;

	System.out.println( "Simulation begins ..." );
        System.out.println( "" );

        // Look for arriving passengers from the data file 
        // or time "ticks"

        error = processSimulationFile();
	System.out.println();

        //  report if an error was encountered during
        //  simulation run.
	if( error ) {
	    System.out.println( "Simulation unsuccessful." );
	} else {
	    System.out.println( "Simulation complete." );
        }
    } //  end runSimulation

    /**
     * Read and process each item in the simulation file.
     * It reads each input item in the file.
     * If a PASSENGER entry, a passenger object is created,
     * and the elevators are checked to see if one is available
     * to service this passenger.  If so, the passenger is
     * logically added to the elevator.  If an elevator
     * is not available, the passenger must take the stairs.
     *
     * If the input item is a TICK, it indicates that one time
     * unit has passed. 
     * At EOF, the method is invoked to shut the elevators down
     * and perform the end of day processing.
     *
     * If an error is detected at any time, this method returns
     * the proper boolean to the calling method.
     *
     * @return   True or False to indicate an error
     *
     */

    private static boolean processSimulationFile () {

        // local constants used by this method

        final String PASSENGER =  "passenger";
        final String TICK = "tick";
        final String SIMULATION_END = "done";
      
	boolean done = false;        // set when done 
	boolean error = false;       // set if error detected
        boolean addedOK = false;     // set if no elevator is available
        Passenger newPass = null;    // new passenger object
        Elevator availableEl = null; // elevator object


	// Read next token from file and process

	try {
	    while( !done && !error && in.nextToken() != in.TT_EOF ) {

                if (in.sval.equals( PASSENGER ) ) {
                    //  if a new passenger, create a new object, look
                    //  for an elevator and add to elevator.  If elevator 
                    //  is not available, passenger takes the stairs.

                    newPass = newPassenger();
                    availableEl = findElevator( newPass ); 
                    if( availableEl == null )
                        takingStairs( newPass );
                    else {
                        System.out.print( "Passenger: " + newPass.getName() 
				+ " arrives on floor " + newPass.getFloor() 
				+ "." );
                        addedOK = availableEl.addPassenger( newPass );
                        if( !addedOK ) {
                            error = true;
                        }
                    }
                } else if (in.sval.equals (TICK)) {
                // token read from file is a time indicator
                    recordTick();

		} else if( in.sval.equals( SIMULATION_END ) ) {
                // end of file == end of workday
                    done = true;
                } else {
                    error = true;
		}      
	    } // end while

            if ( in.nextToken() == in.TT_EOF ) {
                //  perform end of day reporting
                endOfDay();
            }
 
        // catch for file exception 
	} catch ( IOException e ) {
	    error = true;
	} // end try

        return error; 
    } //  end processSimulationFile

    /**
     * This method performs reporting at the end of the
     * workday. It indicates that the elevators have
     * stopped service and reports passenger counts. 
     *
     */

    private static void endOfDay() {

        System.out.println();                          
        System.out.println( "End of workday. Elevators stopping service." );
        System.out.println( "Stopping elevator 1 with " + 
                            elevator1.getTotalPassengers() + " onboard." ); // changed method from getPassengerCount() to getTotalPassengers() edited by MAGNUM
        System.out.println( "Stopping elevator 2 with " + 
                            elevator2.getTotalPassengers() + " onboard." ); // changed method from getPassengerCount() to getTotalPassengers() edited by MAGNUM

    } //  end endOfDay

    /**
     * This method reads in passenger data and builds a new 
     * passenger object. 
     *
     * @return   new Passenger object built from file inputs
     *
     */

    private static Passenger newPassenger() {
        String passengerName = "";
        byte floor = 1;
        Passenger newArrival = null;
	boolean okToContinue = true;

        try {
            in.nextToken();
            passengerName = in.sval;
            in.nextToken();
            floor = (byte) in.nval;
        } catch (IOException e ) {
            System.err.println( "Unexpected error in file! Can't continue." );
	    okToContinue = false;
	    newArrival = null;
        }

        if (okToContinue) {
	    newArrival = new Passenger( passengerName, floor );
        }
        return newArrival;

    } //  end newPassenger

    /**
     * This method checks both elevators to determine if 
     * one is on the floor where this passenger is attempting 
     * to board.
     *
     * It returns a reference to the elevator or a null if no
     * elevator is available.
     *
     * @return   available elevator or a null if no elevator
     * is available.
     *
     */

    private static Elevator findElevator( Passenger passenger ) {
        Elevator foundElevator = null;

        if ( elevator1.isElevatorHere( passenger ) ) {
            foundElevator = elevator1;
        } else if( elevator2.isElevatorHere( passenger ) ) {
            foundElevator = elevator2;
        }	      

        return foundElevator;
    } //  end findElevator

    /**
     * This method tells both elevators that one time unit has passed.
     *
     */

    private static void recordTick() {
       //  tell each elevator that one unit of time has passed
       System.out.println( "Tick." );
       elevator1.tick();
       elevator2.tick();

    } //  end recordTick

    /**
     * This method reports that a passenger is taking stairs 
     * (no elevator is available on the appropriate floor).
     *
     * @param   newPass Passenger object for this passenger
     *
     */

    private static void takingStairs( Passenger newPass ) {
        System.out.print( "Passenger " + newPass.getName() + 
                          " arrives on floor " + newPass.getFloor() + "." );

        System.out.println( " Taking stairs." );
    } //  end takingStairs

} //  ElevatorSimulation 
