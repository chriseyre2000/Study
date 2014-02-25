describe("Regex Hello", function() {
    it("Not Matches Hello", function() {
        expect(regexMatch("hello","world")).toEqual(false);
    });
    
	it("Matches Hello", function() {
        expect(regexMatch("hello","hello")).toEqual(true);
    });

	it("Detect website", function() {
        expect(regexMatch("^http://.*\..*\..*\..*","http://www.pottermore.com")).toEqual(true);
    });

	it("Fail to Detect website", function() {
        expect(regexMatch("^http://.*\..*\..*\..*/(en|en-GB|en-UK)$","http://www.pottermore.co.uk")).toEqual(false);
    });
	
    it("Detects complex website", function() {
        expect(regexMatch("^http://.*\..*\..*\..*/(en|en-GB|en-UK)$","http://www.pottermore.co.uk/en")).toEqual(true);
    });
	
	it("Matches GreatHall", function() {
	    expect(isGreatHall("http://www.pottermore.com/en/great-hall")).toEqual(true);
	});

	it("Matches GreatHall mixed case", function() {
	    expect(isGreatHall("http://www.pottermore.com/en/great-Hall")).toEqual(true);
	});
		
	it("Matches GreatHall en-GB", function() {
	    expect(isGreatHall("http://www.pottermore.com/en-GB/great-hall")).toEqual(true);
	});

	
});