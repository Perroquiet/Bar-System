/*
 * Passenger.java
 *
 * Version:
 *     $Id$
 *
 *
 * Revisions:
 *     $Log$
 */

import java.util.*;

/**
 * This defines a class for a passenger.
 * Passenger objects require a name and incoming
 * floor number.
 *
 * Passenger objects can print themselves and report
 * data attribute values. 
 */

public class Passenger {

    private byte floor;        // floor on which this passenger enters elevator
    private String name;       // name of passenger

    /**
     * Constructor for passenger object
     *
     * @param    inName passenger name
     * @param    inFloor floor passenger is on
     *
     * @return   new passenger object
     */

    public Passenger( String inName, byte inFloor ) {
        floor = inFloor;
        name = inName;
    } //  end constructor

    /**
     * Debug routine to print this object
     *
     */

    public void print () {
        System.out.println( " This is passenger  " + name + " on floor " 
                            + floor );
    } //  end print

    /**
     * Return name associated with this passenger
     *
     * @return   passenger name
     *
     */

     public String getName() {
         return name;
     } //  end getName

    /**
     * Return floor associated with this passenger
     *
     * @return   floor on which this passenger entered elevator
     *
     */

    public byte getFloor () {
        return floor;
    } //  end getFloor

} //  Passenger 
