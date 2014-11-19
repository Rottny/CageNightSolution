CageNightSolution
=================

CageNightSolution_141119_1546

+++++ TODO-list: ++++++++++++++++++++


		- Clean and remove unnessecary code.

		- Rewrite the Get-Method to check for other properties than just the ID when sending a whole item.

		- Implement IComparer or IComparable interface to compare collection-items ( Video, Genre, Customer or VideoBooking ) 

		- Use a class specififying structs for each type, instead of whole Objects when getting an item from the database.
		  We use the structs when temporarily storing values when manipulating Objects.
		  I.E "say that we wan't to Update an Item from the UI. First we get the information from the UI storing it in a 'dummy-struct'
			  ..that we later can use for representation in the UI layer. ( We represent the old item with values stored in the dummy-struct ).
		   oldDummyStructItem.ID = ((Video)cboMainTabVideo.SelectedItem).Id ....etc!! OR we can use a Struct-contructor!



+++++ FIXED: +++++++++++++++++++++++

FIXED! CUSTOMER AND VIDEO on MAINTENANCE-TAB NEEDS A COMPLETE REWORK! Pick a task on Trello and complete it.

FIXED! Implement Erics sorting to the booking-tab using the current structure of FormFunctions! Look in EricsBookingSorting.txt!

FIXED! Migrate logic from DataBase to Booking!

FIXED! Removed Test-tab!

FIXED! Genre, Customer and Video can no longer update an existing Name to another existing Genre!

FIXED! DataBase Add, Delete and Update now propagates a VideoRentalException if a normal exception was found when using Dictionary.Add/Remove.

FIXED! Maintenance-VideoGroup: Now able to Update Genre and NrOfDaysWOPenalty for an existing Video with messagebox-output!

FIXED! The GetCollection-methods from Booking throws an exception wich messes upp the logic when trying to check for empty dictionaries.
	Instead of using booking.GetCollectionXXX() method we can use a new property in DataBase/IDataLayer that holds the current length of the dictionary.

	I.E			if ( booking.VideoCount != 0 ) 
				{ var videos = booking.GetVideoCollection();	//do stuff }

	This will avoid VideoRentalExceptions. So Only use GetCollectionXXX-methods when you are sure there are items available in the dictionary!
	Alot of code uses this old implementation and assumes no lists are empty, this needs to be corrected.

	
FIXED! Fix UpdateAndFillMaintenance-tab to ONLY update specific groups! ( Video, Customer, Genre ).

FIXED! Migrate Add, Update and Delete button-functions to FormFunctions!
