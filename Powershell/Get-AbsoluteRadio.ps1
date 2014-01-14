function absolute-radio([int]$page, [int]$limit = 50) {
    $a = Invoke-WebRequest -Uri "http://www.absoluteradio.co.uk/playlist/feeds/?service=abr&limit=$limit&page=$page" | select content
    [xml]$b = $a.Content
    $b.played.tracks.track | % { 
        $parts = $_.url -split "/";
        $song = $_.name;
        $artist = $_.artist.InnerText;
        if ($artist  -eq $null) { $artist = $_.artist }

        [PSCustomObject]@{
            Artist = $artist;
            Song = $song;
            Played = "$($_.played.`"#text`")"}   }
 }