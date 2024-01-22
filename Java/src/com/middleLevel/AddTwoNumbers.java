/**
 * 
 */
package com.middleLevel;

import java.util.Iterator;

/**
 * 
 */
public class AddTwoNumbers {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		int[] firstNumberArray = {1,2,3,4,5,6,7};
		int[] secondNumberArray = {9,9,9,9};
		
		if (firstNumberArray.length > 0) {
			ListNode firstNumbersArrayFirstReferencing = new ListNode(firstNumberArray[0]);
			ListNode current = firstNumbersArrayFirstReferencing;
			for (int i = 1; i < firstNumberArray.length; i++) {
				current.next = new ListNode(firstNumberArray[i]);
				//only referencing/pointer update, not class's field values
				current = current.next;
			}
			
			current = firstNumbersArrayFirstReferencing;
			while (current != null) {
				System.out.println(current.val);
				current = current.next;
			}
		}
		
		if (secondNumberArray.length > 0) {
			
		}

	}
//	public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
//		   
//    }


}
