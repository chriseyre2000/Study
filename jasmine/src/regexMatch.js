function regexMatch(pattern, subject) {
	var reg = new RegExp(pattern)
	
	return subject.match(reg) != null
}

function isGreatHall(subject) {

   var greatHallPattern = new RegExp("http://www.pottermore.com/en(|-..)/great-hall","i")
   return subject.match(greatHallPattern) != null

}