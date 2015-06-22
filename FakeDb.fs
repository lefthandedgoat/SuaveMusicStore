module SuaveMusicStore.Db

open System

type DbContext =  { dbcontext : Object }
type Album = { AlbumId : int; GenreId : int; ArtistId : int; Title : string; Price : Decimal; AlbumArtUrl : string }
type Artist = { ArtistId : int; Name : string}
type Genre = { GenreId : int; Name : string; Description : string }
type AlbumDetails = { AlbumId : int;  AlbumArtUrl : string; Price : Decimal; Title : string; Artist : string; Genre : string }
type User = { UserId : int; UserName : string; Email : string; Password : string; Role : string }
type Cart = { RecordId : int; CartId : int; AlbumId : int; Count : int; DateCreated : System.DateTime }
type CartDetails = { CartId : int; Count : int; AlbumTitle : string; AlbumId : int; Price : Decimal }
type BestSeller = { AlbumId : int; Title : string; AlbumArtUrl : string; Count : int }

let getContext() = { dbcontext = null }

let firstOrNone s = s |> Seq.tryFind (fun _ -> true)

let getGenres (ctx : DbContext) : Genre list =
  [
    { GenreId = 1; Name = "Rock"; Description = "Rock and Roll is a form of rock music developed in the 1950s and 1960s. Rock music combines many kinds of music from the United States, such as country music, folk music, church music, work songs, blues and jazz." }
    { GenreId = 2; Name = "Jazz"; Description = "Jazz is a type of music which was invented in the United States. Jazz music combines African-American music with European music. Some common jazz instruments include the saxophone, trumpet, piano, double bass, and drums." }
    { GenreId = 3; Name = "Metal"; Description = "Heavy Metal is a loud, aggressive style of Rock music. The bands who play heavy-metal music usually have one or two guitars, a bass guitar and drums. In some bands, electronic keyboards, organs, or other instruments are used. Heavy metal songs are loud and powerful-sounding, and have strong rhythms that are repeated. There are many different types of Heavy Metal, some of which are described below. Heavy metal bands sometimes dress in jeans, leather jackets, and leather boots, and have long hair. Heavy metal bands sometimes behave in a dramatic way when they play their instruments or sing. However, many heavy metal bands do not like to do this." }
    { GenreId = 4; Name = "Alternative"; Description = "Alternative rock is a type of rock music that became popular in the 1980s and became widely popular in the 1990s. Alternative rock is made up of various subgenres that have come out of the indie music scene since the 1980s, such as grunge, indie rock, Britpop, gothic rock, and indie pop. These genres are sorted by their collective types of punk, which laid the groundwork for alternative music in the 1970s." }
    { GenreId = 5; Name = "Disco"; Description = """Disco is a style of pop music that was popular in the mid-1970s. Disco music has a strong beat that people can dance to. People usually dance to disco music at bars called disco clubs. The word "disco" is also used to refer to the style of dancing that people do to disco music, or to the style of clothes that people wear to go disco dancing. Disco was at its most popular in the United States and Europe in the 1970s and early 1980s. Disco was brought into the mainstream by the hit movie Saturday Night Fever, which was released in 1977. This movie, which starred John Travolta, showed people doing disco dancing. Many radio stations played disco in the late 1970s.""" }
    { GenreId = 6; Name = "Blues"; Description = "The blues is a form of music that started in the United States during the start of the 20th century. It was started by former African slaves from spirituals, praise songs, and chants. The first blues songs were called Delta blues. These songs came from the area near the mouth of the Mississippi River." }
    { GenreId = 7; Name = "Latin"; Description = "Latin American music is the music of all countries in Latin America (and the Caribbean) and comes in many varieties. Latin America is home to musical styles such as the simple, rural conjunto music of northern Mexico, the sophisticated habanera of Cuba, the rhythmic sounds of the Puerto Rican plena, the symphonies of Heitor Villa-Lobos, and the simple and moving Andean flute. Music has played an important part recently in Latin America's politics, the nueva canción movement being a prime example. Latin music is very diverse, with the only truly unifying thread being the use of Latin-derived languages, predominantly the Spanish language, the Portuguese language in Brazil, and to a lesser extent, Latin-derived creole languages, such as those found in Haiti." }
    { GenreId = 8; Name = "Reggae"; Description = "Reggae is a music genre first developed in Jamaica in the late 1960s. While sometimes used in a broader sense to refer to most types of Jamaican music, the term reggae more properly denotes a particular music style that originated following on the development of ska and rocksteady." }
    { GenreId = 9; Name = "Pop"; Description = "Pop music is a music genre that developed from the mid-1950s as a softer alternative to rock 'n' roll and later to rock music. It has a focus on commercial recording, often oriented towards a youth market, usually through the medium of relatively short and simple love songs. While these basic elements of the genre have remained fairly constant, pop music has absorbed influences from most other forms of popular music, particularly borrowing from the development of rock music, and utilizing key technological innovations to produce new variations on existing themes." }
    { GenreId = 10; Name = "Classical"; Description = """Classical music is a very general term which normally refers to the standard music of countries in the Western world. It is music that has been composed by musicians who are trained in the art of writing music (composing) and written down in music notation so that other musicians can play it. Classical music can also be described as "art music" because great art (skill) is needed to compose it and to perform it well. Classical music differs from pop music because it is not made just in order to be popular for a short time or just to be a commercial success.""" }
  ]

let private allAlbums =
  [
    { AlbumId = 1; GenreId = 1; ArtistId = 1; Title = "For Those About To Rock We Salute You"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 2; GenreId = 1; ArtistId = 1; Title = "Let There Be Rock"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 3; GenreId = 1; ArtistId = 100; Title = "Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 4; GenreId = 1; ArtistId = 102; Title = "Misplaced Childhood"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 5; GenreId = 1; ArtistId = 105; Title = "The Best Of Men At Work"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 7; GenreId = 1; ArtistId = 110; Title = "Nevermind"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 8; GenreId = 1; ArtistId = 111; Title = "Compositores"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 9; GenreId = 1; ArtistId = 114; Title = "Bark at the Moon (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 10; GenreId = 1; ArtistId = 114; Title = "Blizzard of Ozz"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 11; GenreId = 1; ArtistId = 114; Title = "Diary of a Madman (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 12; GenreId = 1; ArtistId = 114; Title = "No More Tears (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 13; GenreId = 1; ArtistId = 114; Title = "Speak of the Devil"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 14; GenreId = 1; ArtistId = 115; Title = "Walking Into Clarksdale"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 15; GenreId = 1; ArtistId = 117; Title = "The Beast Live"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 16; GenreId = 1; ArtistId = 118; Title = "Live On Two Legs [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 17; GenreId = 1; ArtistId = 118; Title = "Riot Act"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 18; GenreId = 1; ArtistId = 118; Title = "Ten"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 19; GenreId = 1; ArtistId = 118; Title = "Vs."; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 20; GenreId = 1; ArtistId = 120; Title = "Dark Side Of The Moon"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 21; GenreId = 1; ArtistId = 124; Title = "New Adventures In Hi-Fi"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 22; GenreId = 1; ArtistId = 126; Title = "Raul Seixas"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 23; GenreId = 1; ArtistId = 127; Title = "By The Way"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 24; GenreId = 1; ArtistId = 127; Title = "Californication"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 25; GenreId = 1; ArtistId = 128; Title = "Retrospective I (1974-1980)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 26; GenreId = 1; ArtistId = 130; Title = "Maquinarama"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 27; GenreId = 1; ArtistId = 130; Title = "O Samba Poconé"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 28; GenreId = 1; ArtistId = 132; Title = "A-Sides"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 29; GenreId = 1; ArtistId = 134; Title = "Core"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 30; GenreId = 1; ArtistId = 136; Title = "[1997] Black Light Syndrome"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 31; GenreId = 1; ArtistId = 139; Title = "Beyond Good And Evil"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 33; GenreId = 1; ArtistId = 140; Title = "The Doors"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 34; GenreId = 1; ArtistId = 141; Title = "The Police Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 35; GenreId = 1; ArtistId = 142; Title = "Hot Rocks, 1964-1971 (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 36; GenreId = 1; ArtistId = 142; Title = "No Security"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 37; GenreId = 1; ArtistId = 142; Title = "Voodoo Lounge"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 38; GenreId = 1; ArtistId = 144; Title = "My Generation - The Very Best Of The Who"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 39; GenreId = 1; ArtistId = 150; Title = "Achtung Baby"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 40; GenreId = 1; ArtistId = 150; Title = "B-Sides 1980-1990"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 41; GenreId = 1; ArtistId = 150; Title = "How To Dismantle An Atomic Bomb"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 42; GenreId = 1; ArtistId = 150; Title = "Pop"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 43; GenreId = 1; ArtistId = 150; Title = "Rattle And Hum"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 44; GenreId = 1; ArtistId = 150; Title = "The Best Of 1980-1990"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 45; GenreId = 1; ArtistId = 150; Title = "War"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 46; GenreId = 1; ArtistId = 150; Title = "Zooropa"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 47; GenreId = 1; ArtistId = 152; Title = "Diver Down"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 48; GenreId = 1; ArtistId = 152; Title = "The Best Of Van Halen, Vol. I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 49; GenreId = 1; ArtistId = 152; Title = "Van Halen III"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 50; GenreId = 1; ArtistId = 152; Title = "Van Halen"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 51; GenreId = 1; ArtistId = 153; Title = "Contraband"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 52; GenreId = 1; ArtistId = 157; Title = "Un-Led-Ed"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 54; GenreId = 1; ArtistId = 2; Title = "Balls to the Wall"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 55; GenreId = 1; ArtistId = 2; Title = "Restless and Wild"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 56; GenreId = 1; ArtistId = 200; Title = "Every Kind of Light"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 57; GenreId = 1; ArtistId = 22; Title = "BBC Sessions [Disc 1] [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 58; GenreId = 1; ArtistId = 22; Title = "BBC Sessions [Disc 2] [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 59; GenreId = 1; ArtistId = 22; Title = "Coda"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 60; GenreId = 1; ArtistId = 22; Title = "Houses Of The Holy"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 61; GenreId = 1; ArtistId = 22; Title = "In Through The Out Door"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 62; GenreId = 1; ArtistId = 22; Title = "IV"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 63; GenreId = 1; ArtistId = 22; Title = "Led Zeppelin I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 64; GenreId = 1; ArtistId = 22; Title = "Led Zeppelin II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 65; GenreId = 1; ArtistId = 22; Title = "Led Zeppelin III"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 66; GenreId = 1; ArtistId = 22; Title = "Physical Graffiti [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 67; GenreId = 1; ArtistId = 22; Title = "Physical Graffiti [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 68; GenreId = 1; ArtistId = 22; Title = "Presence"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 69; GenreId = 1; ArtistId = 22; Title = "The Song Remains The Same (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 70; GenreId = 1; ArtistId = 22; Title = "The Song Remains The Same (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 71; GenreId = 1; ArtistId = 23; Title = "Bongo Fury"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 72; GenreId = 1; ArtistId = 3; Title = "Big Ones"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 73; GenreId = 1; ArtistId = 4; Title = "Jagged Little Pill"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 74; GenreId = 1; ArtistId = 5; Title = "Facelift"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 75; GenreId = 1; ArtistId = 51; Title = "Greatest Hits I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 76; GenreId = 1; ArtistId = 51; Title = "Greatest Hits II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 77; GenreId = 1; ArtistId = 51; Title = "News Of The World"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 78; GenreId = 1; ArtistId = 52; Title = "Greatest Kiss"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 79; GenreId = 1; ArtistId = 52; Title = "Unplugged [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 80; GenreId = 1; ArtistId = 55; Title = "Into The Light"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 81; GenreId = 1; ArtistId = 58; Title = "Come Taste The Band"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 82; GenreId = 1; ArtistId = 58; Title = "Deep Purple In Rock"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 83; GenreId = 1; ArtistId = 58; Title = "Fireball"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 84; GenreId = 1; ArtistId = 58; Title = "Machine Head"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 85; GenreId = 1; ArtistId = 58; Title = "MK III The Final Concerts [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 86; GenreId = 1; ArtistId = 58; Title = "Purpendicular"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 87; GenreId = 1; ArtistId = 58; Title = "Slaves And Masters"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 88; GenreId = 1; ArtistId = 58; Title = "Stormbringer"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 89; GenreId = 1; ArtistId = 58; Title = "The Battle Rages On"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 90; GenreId = 1; ArtistId = 58; Title = "The Final Concerts (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 91; GenreId = 1; ArtistId = 59; Title = "Santana - As Years Go By"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 92; GenreId = 1; ArtistId = 59; Title = "Santana Live"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 93; GenreId = 1; ArtistId = 59; Title = "Supernatural"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 94; GenreId = 1; ArtistId = 76; Title = "Chronicle, Vol. 1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 95; GenreId = 1; ArtistId = 76; Title = "Chronicle, Vol. 2"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 96; GenreId = 1; ArtistId = 8; Title = "Audioslave"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 97; GenreId = 1; ArtistId = 82; Title = "King For A Day Fool For A Lifetime"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 98; GenreId = 1; ArtistId = 84; Title = "In Your Honor [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 99; GenreId = 1; ArtistId = 84; Title = "In Your Honor [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 100; GenreId = 1; ArtistId = 84; Title = "The Colour And The Shape"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 101; GenreId = 1; ArtistId = 88; Title = "Appetite for Destruction"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 102; GenreId = 1; ArtistId = 88; Title = "Use Your Illusion I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 103; GenreId = 1; ArtistId = 90; Title = "A Matter of Life and Death"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 104; GenreId = 1; ArtistId = 90; Title = "Brave New World"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 105; GenreId = 1; ArtistId = 90; Title = "Fear Of The Dark"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 106; GenreId = 1; ArtistId = 90; Title = "Live At Donington 1992 (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 107; GenreId = 1; ArtistId = 90; Title = "Live At Donington 1992 (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 108; GenreId = 1; ArtistId = 90; Title = "Rock In Rio [CD2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 109; GenreId = 1; ArtistId = 90; Title = "The Number of The Beast"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 110; GenreId = 1; ArtistId = 90; Title = "The X Factor"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 111; GenreId = 1; ArtistId = 90; Title = "Virtual XI"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 112; GenreId = 1; ArtistId = 92; Title = "Emergency On Planet Earth"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 113; GenreId = 1; ArtistId = 94; Title = "Are You Experienced?"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 114; GenreId = 1; ArtistId = 95; Title = "Surfing with the Alien (Remastered)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 115; GenreId = 10; ArtistId = 203; Title = "The Best of Beethoven"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 119; GenreId = 10; ArtistId = 208; Title = "Pachelbel: Canon & Gigue"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 122; GenreId = 10; ArtistId = 211; Title = "Bach: Goldberg Variations"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 123; GenreId = 10; ArtistId = 212; Title = "Bach: The Cello Suites"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 124; GenreId = 10; ArtistId = 213; Title = "Handel: The Messiah (Highlights)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 128; GenreId = 10; ArtistId = 217; Title = "Haydn: Symphonies 99 - 104"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 130; GenreId = 10; ArtistId = 219; Title = "A Soprano Inspired"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 132; GenreId = 10; ArtistId = 221; Title = "Wagner: Favourite Overtures"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 134; GenreId = 10; ArtistId = 223; Title = "Tchaikovsky: The Nutcracker"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 135; GenreId = 10; ArtistId = 224; Title = "The Last Night of the Proms"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 138; GenreId = 10; ArtistId = 226; Title = "Respighi:Pines of Rome"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 139; GenreId = 10; ArtistId = 226; Title = "Strauss: Waltzes"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 140; GenreId = 10; ArtistId = 229; Title = "Carmina Burana"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 141; GenreId = 10; ArtistId = 230; Title = "A Copland Celebration, Vol. I"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 142; GenreId = 10; ArtistId = 231; Title = "Bach: Toccata & Fugue in D Minor"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 143; GenreId = 10; ArtistId = 232; Title = "Prokofiev: Symphony No.1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 144; GenreId = 10; ArtistId = 233; Title = "Scheherazade"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 145; GenreId = 10; ArtistId = 234; Title = "Bach: The Brandenburg Concertos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 147; GenreId = 10; ArtistId = 236; Title = "Mascagni: Cavalleria Rusticana"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 148; GenreId = 10; ArtistId = 237; Title = "Sibelius: Finlandia"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 152; GenreId = 10; ArtistId = 242; Title = "Adams, John: The Chairman Dances"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 154; GenreId = 10; ArtistId = 245; Title = "Berlioz: Symphonie Fantastique"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 155; GenreId = 10; ArtistId = 245; Title = "Prokofiev: Romeo & Juliet"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 157; GenreId = 10; ArtistId = 247; Title = "English Renaissance"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 159; GenreId = 10; ArtistId = 248; Title = "Mozart: Symphonies Nos. 40 & 41"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 161; GenreId = 10; ArtistId = 250; Title = "SCRIABIN: Vers la flamme"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 163; GenreId = 10; ArtistId = 255; Title = "Bartok: Violin & Viola Concertos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 166; GenreId = 10; ArtistId = 259; Title = "South American Getaway"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 167; GenreId = 10; ArtistId = 260; Title = "Górecki: Symphony No. 3"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 168; GenreId = 10; ArtistId = 261; Title = "Purcell: The Fairy Queen"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 171; GenreId = 10; ArtistId = 264; Title = "Weill: The Seven Deadly Sins"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 173; GenreId = 10; ArtistId = 266; Title = "Szymanowski: Piano Works, Vol. 1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 174; GenreId = 10; ArtistId = 267; Title = "Nielsen: The Six Symphonies"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 177; GenreId = 10; ArtistId = 274; Title = "Mozart: Chamber Music"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 178; GenreId = 2; ArtistId = 10; Title = "The Best Of Billy Cobham"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 179; GenreId = 2; ArtistId = 197; Title = "Quiet Songs"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 180; GenreId = 2; ArtistId = 202; Title = "Worlds"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 181; GenreId = 2; ArtistId = 27; Title = "Quanta Gente Veio ver--Bônus De Carnaval"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 182; GenreId = 2; ArtistId = 53; Title = "Heart of the Night"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 183; GenreId = 2; ArtistId = 53; Title = "Morning Dance"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 184; GenreId = 2; ArtistId = 6; Title = "Warner 25 Anos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 185; GenreId = 2; ArtistId = 68; Title = "Miles Ahead"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 186; GenreId = 2; ArtistId = 68; Title = "The Essential Miles Davis [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 187; GenreId = 2; ArtistId = 68; Title = "The Essential Miles Davis [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 188; GenreId = 2; ArtistId = 79; Title = "Outbreak"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 189; GenreId = 2; ArtistId = 89; Title = "Blue Moods"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 190; GenreId = 3; ArtistId = 100; Title = "Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 191; GenreId = 3; ArtistId = 106; Title = "Ace Of Spades"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 192; GenreId = 3; ArtistId = 109; Title = "Motley Crue Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 193; GenreId = 3; ArtistId = 11; Title = "Alcohol Fueled Brewtality Live! [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 194; GenreId = 3; ArtistId = 11; Title = "Alcohol Fueled Brewtality Live! [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 195; GenreId = 3; ArtistId = 114; Title = "Tribute"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 196; GenreId = 3; ArtistId = 12; Title = "Black Sabbath Vol. 4 (Remaster)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 197; GenreId = 3; ArtistId = 12; Title = "Black Sabbath"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 198; GenreId = 3; ArtistId = 135; Title = "Mezmerize"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 199; GenreId = 3; ArtistId = 14; Title = "Chemical Wedding"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 200; GenreId = 3; ArtistId = 50; Title = "...And Justice For All"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 201; GenreId = 3; ArtistId = 50; Title = "Black Album"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 202; GenreId = 3; ArtistId = 50; Title = "Garage Inc. (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 203; GenreId = 3; ArtistId = 50; Title = "Garage Inc. (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 204; GenreId = 3; ArtistId = 50; Title = "Load"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 205; GenreId = 3; ArtistId = 50; Title = "Master Of Puppets"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 206; GenreId = 3; ArtistId = 50; Title = "ReLoad"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 207; GenreId = 3; ArtistId = 50; Title = "Ride The Lightning"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 208; GenreId = 3; ArtistId = 50; Title = "St. Anger"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 209; GenreId = 3; ArtistId = 7; Title = "Plays Metallica By Four Cellos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 210; GenreId = 3; ArtistId = 87; Title = "Faceless"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 211; GenreId = 3; ArtistId = 88; Title = "Use Your Illusion II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 212; GenreId = 3; ArtistId = 90; Title = "A Real Dead One"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 213; GenreId = 3; ArtistId = 90; Title = "A Real Live One"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 214; GenreId = 3; ArtistId = 90; Title = "Live After Death"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 215; GenreId = 3; ArtistId = 90; Title = "No Prayer For The Dying"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 216; GenreId = 3; ArtistId = 90; Title = "Piece Of Mind"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 217; GenreId = 3; ArtistId = 90; Title = "Powerslave"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 218; GenreId = 3; ArtistId = 90; Title = "Rock In Rio [CD1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 219; GenreId = 3; ArtistId = 90; Title = "Rock In Rio [CD2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 220; GenreId = 3; ArtistId = 90; Title = "Seventh Son of a Seventh Son"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 221; GenreId = 3; ArtistId = 90; Title = "Somewhere in Time"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 222; GenreId = 3; ArtistId = 90; Title = "The Number of The Beast"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 223; GenreId = 3; ArtistId = 98; Title = "Living After Midnight"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 224; GenreId = 4; ArtistId = 196; Title = "Cake: B-Sides and Rarities"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 225; GenreId = 4; ArtistId = 204; Title = "Temple of the Dog"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 226; GenreId = 4; ArtistId = 205; Title = "Carry On"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 227; GenreId = 4; ArtistId = 253; Title = "Carried to Dust (Bonus Track Version)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 228; GenreId = 4; ArtistId = 8; Title = "Revelations"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 229; GenreId = 6; ArtistId = 133; Title = "In Step"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 230; GenreId = 6; ArtistId = 137; Title = "Live [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 231; GenreId = 6; ArtistId = 137; Title = "Live [Disc 2]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 233; GenreId = 6; ArtistId = 81; Title = "The Cream Of Clapton"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 234; GenreId = 6; ArtistId = 81; Title = "Unplugged"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 235; GenreId = 6; ArtistId = 90; Title = "Iron Maiden"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 238; GenreId = 7; ArtistId = 103; Title = "Barulhinho Bom"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 239; GenreId = 7; ArtistId = 112; Title = "Olodum"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 240; GenreId = 7; ArtistId = 113; Title = "Acústico MTV"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 241; GenreId = 7; ArtistId = 113; Title = "Arquivo II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 242; GenreId = 7; ArtistId = 113; Title = "Arquivo Os Paralamas Do Sucesso"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 243; GenreId = 7; ArtistId = 145; Title = "Serie Sem Limite (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 244; GenreId = 7; ArtistId = 145; Title = "Serie Sem Limite (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 245; GenreId = 7; ArtistId = 155; Title = "Ao Vivo [IMPORT]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 246; GenreId = 7; ArtistId = 16; Title = "Prenda Minha"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 247; GenreId = 7; ArtistId = 16; Title = "Sozinho Remix Ao Vivo"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 248; GenreId = 7; ArtistId = 17; Title = "Minha Historia"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 249; GenreId = 7; ArtistId = 18; Title = "Afrociberdelia"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 250; GenreId = 7; ArtistId = 18; Title = "Da Lama Ao Caos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 251; GenreId = 7; ArtistId = 20; Title = "Na Pista"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 252; GenreId = 7; ArtistId = 201; Title = "Duos II"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 253; GenreId = 7; ArtistId = 21; Title = "Sambas De Enredo 2001"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 254; GenreId = 7; ArtistId = 21; Title = "Vozes do MPB"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 255; GenreId = 7; ArtistId = 24; Title = "Chill: Brazil (Disc 1)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 256; GenreId = 7; ArtistId = 27; Title = "Quanta Gente Veio Ver (Live)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 257; GenreId = 7; ArtistId = 37; Title = "The Best of Ed Motta"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 258; GenreId = 7; ArtistId = 41; Title = "Elis Regina-Minha História"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 259; GenreId = 7; ArtistId = 42; Title = "Milton Nascimento Ao Vivo"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 260; GenreId = 7; ArtistId = 42; Title = "Minas"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 261; GenreId = 7; ArtistId = 46; Title = "Jorge Ben Jor 25 Anos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 262; GenreId = 7; ArtistId = 56; Title = "Meus Momentos"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 263; GenreId = 7; ArtistId = 6; Title = "Chill: Brazil (Disc 2)"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 264; GenreId = 7; ArtistId = 72; Title = "Vinicius De Moraes"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 266; GenreId = 7; ArtistId = 77; Title = "Cássia Eller - Sem Limite [Disc 1]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 267; GenreId = 7; ArtistId = 80; Title = "Djavan Ao Vivo - Vol. 02"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 268; GenreId = 7; ArtistId = 80; Title = "Djavan Ao Vivo - Vol. 1"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 269; GenreId = 7; ArtistId = 81; Title = "Unplugged"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 270; GenreId = 7; ArtistId = 83; Title = "Deixa Entrar"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 271; GenreId = 7; ArtistId = 86; Title = "Roda De Funk"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 272; GenreId = 7; ArtistId = 96; Title = "Jota Quest-1995"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 274; GenreId = 7; ArtistId = 99; Title = "Mais Do Mesmo"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 275; GenreId = 8; ArtistId = 100; Title = "Greatest Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 276; GenreId = 8; ArtistId = 151; Title = "UB40 The Best Of - Volume Two [UK]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 277; GenreId = 8; ArtistId = 19; Title = "Acústico MTV [Live]"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 278; GenreId = 8; ArtistId = 19; Title = "Cidade Negra - Hits"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 280; GenreId = 9; ArtistId = 21; Title = "Axé Bahia 2001"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 281; GenreId = 9; ArtistId = 252; Title = "Frank"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 282; GenreId = 5; ArtistId = 276; Title = "Le Freak"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 283; GenreId = 5; ArtistId = 278; Title = "MacArthur Park Suite"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
    { AlbumId = 284; GenreId = 5; ArtistId = 277; Title = "Ring My Bell"; Price = 8.99M; AlbumArtUrl = "/placeholder.gif" }
  ]

let getArtists (ctx : DbContext) : Artist list =
  [
    { ArtistId = 1; Name = "AC/DC" }
    { ArtistId = 2; Name = "Accept" }
    { ArtistId = 3; Name = "Aerosmith" }
    { ArtistId = 4; Name = "Alanis Morissette" }
    { ArtistId = 5; Name = "Alice In Chains" }
    { ArtistId = 6; Name = "Antônio Carlos Jobim" }
    { ArtistId = 7; Name = "Apocalyptica" }
    { ArtistId = 8; Name = "Audioslave" }
    { ArtistId = 10; Name = "Billy Cobham" }
    { ArtistId = 11; Name = "Black Label Society" }
    { ArtistId = 12; Name = "Black Sabbath" }
    { ArtistId = 14; Name = "Bruce Dickinson" }
    { ArtistId = 15; Name = "Buddy Guy" }
    { ArtistId = 16; Name = "Caetano Veloso" }
    { ArtistId = 17; Name = "Chico Buarque" }
    { ArtistId = 18; Name = "Chico Science & Nação Zumbi" }
    { ArtistId = 19; Name = "Cidade Negra" }
    { ArtistId = 20; Name = "Cláudio Zoli" }
    { ArtistId = 21; Name = "Various Artists" }
    { ArtistId = 22; Name = "Led Zeppelin" }
    { ArtistId = 23; Name = "Frank Zappa & Captain Beefheart" }
    { ArtistId = 24; Name = "Marcos Valle" }
    { ArtistId = 27; Name = "Gilberto Gil" }
    { ArtistId = 37; Name = "Ed Motta" }
    { ArtistId = 41; Name = "Elis Regina" }
    { ArtistId = 42; Name = "Milton Nascimento" }
    { ArtistId = 46; Name = "Jorge Ben" }
    { ArtistId = 50; Name = "Metallica" }
    { ArtistId = 51; Name = "Queen" }
    { ArtistId = 52; Name = "Kiss" }
    { ArtistId = 53; Name = "Spyro Gyra" }
    { ArtistId = 55; Name = "David Coverdale" }
    { ArtistId = 56; Name = "Gonzaguinha" }
    { ArtistId = 58; Name = "Deep Purple" }
    { ArtistId = 59; Name = "Santana" }
    { ArtistId = 68; Name = "Miles Davis" }
    { ArtistId = 72; Name = "Vinícius De Moraes" }
    { ArtistId = 76; Name = "Creedence Clearwater Revival" }
    { ArtistId = 77; Name = "Cássia Eller" }
    { ArtistId = 79; Name = "Dennis Chambers" }
    { ArtistId = 80; Name = "Djavan" }
    { ArtistId = 81; Name = "Eric Clapton" }
    { ArtistId = 82; Name = "Faith No More" }
    { ArtistId = 83; Name = "Falamansa" }
    { ArtistId = 84; Name = "Foo Fighters" }
    { ArtistId = 86; Name = "Funk Como Le Gusta" }
    { ArtistId = 87; Name = "Godsmack" }
    { ArtistId = 88; Name = "Guns N' Roses" }
    { ArtistId = 89; Name = "Incognito" }
    { ArtistId = 90; Name = "Iron Maiden" }
    { ArtistId = 92; Name = "Jamiroquai" }
    { ArtistId = 94; Name = "Jimi Hendrix" }
    { ArtistId = 95; Name = "Joe Satriani" }
    { ArtistId = 96; Name = "Jota Quest" }
    { ArtistId = 98; Name = "Judas Priest" }
    { ArtistId = 99; Name = "Legião Urbana" }
    { ArtistId = 100; Name = "Lenny Kravitz" }
    { ArtistId = 101; Name = "Lulu Santos" }
    { ArtistId = 102; Name = "Marillion" }
    { ArtistId = 103; Name = "Marisa Monte" }
    { ArtistId = 105; Name = "Men At Work" }
    { ArtistId = 106; Name = "Motörhead" }
    { ArtistId = 109; Name = "Mötley Crüe" }
    { ArtistId = 110; Name = "Nirvana" }
    { ArtistId = 111; Name = "O Terço" }
    { ArtistId = 112; Name = "Olodum" }
    { ArtistId = 113; Name = "Os Paralamas Do Sucesso" }
    { ArtistId = 114; Name = "Ozzy Osbourne" }
    { ArtistId = 115; Name = "Page & Plant" }
    { ArtistId = 117; Name = "Paul D'Ianno" }
    { ArtistId = 118; Name = "Pearl Jam" }
    { ArtistId = 120; Name = "Pink Floyd" }
    { ArtistId = 124; Name = "R.E.M." }
    { ArtistId = 126; Name = "Raul Seixas" }
    { ArtistId = 127; Name = "Red Hot Chili Peppers" }
    { ArtistId = 128; Name = "Rush" }
    { ArtistId = 130; Name = "Skank" }
    { ArtistId = 132; Name = "Soundgarden" }
    { ArtistId = 133; Name = "Stevie Ray Vaughan & Double Trouble" }
    { ArtistId = 134; Name = "Stone Temple Pilots" }
    { ArtistId = 135; Name = "System Of A Down" }
    { ArtistId = 136; Name = "Terry Bozzio, Tony Levin & Steve Stevens" }
    { ArtistId = 137; Name = "The Black Crowes" }
    { ArtistId = 139; Name = "The Cult" }
    { ArtistId = 140; Name = "The Doors" }
    { ArtistId = 141; Name = "The Police" }
    { ArtistId = 142; Name = "The Rolling Stones" }
    { ArtistId = 144; Name = "The Who" }
    { ArtistId = 145; Name = "Tim Maia" }
    { ArtistId = 150; Name = "U2" }
    { ArtistId = 151; Name = "UB40" }
    { ArtistId = 152; Name = "Van Halen" }
    { ArtistId = 153; Name = "Velvet Revolver" }
    { ArtistId = 155; Name = "Zeca Pagodinho" }
    { ArtistId = 157; Name = "Dread Zeppelin" }
    { ArtistId = 179; Name = "Scorpions" }
    { ArtistId = 196; Name = "Cake" }
    { ArtistId = 197; Name = "Aisha Duo" }
    { ArtistId = 200; Name = "The Posies" }
    { ArtistId = 201; Name = "Luciana Souza/Romero Lubambo" }
    { ArtistId = 202; Name = "Aaron Goldberg" }
    { ArtistId = 203; Name = "Nicolaus Esterhazy Sinfonia" }
    { ArtistId = 204; Name = "Temple of the Dog" }
    { ArtistId = 205; Name = "Chris Cornell" }
    { ArtistId = 206; Name = "Alberto Turco & Nova Schola Gregoriana" }
    { ArtistId = 208; Name = "English Concert & Trevor Pinnock" }
    { ArtistId = 211; Name = "Wilhelm Kempff" }
    { ArtistId = 212; Name = "Yo-Yo Ma" }
    { ArtistId = 213; Name = "Scholars Baroque Ensemble" }
    { ArtistId = 217; Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" }
    { ArtistId = 219; Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" }
    { ArtistId = 221; Name = "Sir Georg Solti & Wiener Philharmoniker" }
    { ArtistId = 223; Name = "London Symphony Orchestra & Sir Charles Mackerras" }
    { ArtistId = 224; Name = "Barry Wordsworth & BBC Concert Orchestra" }
    { ArtistId = 226; Name = "Eugene Ormandy" }
    { ArtistId = 229; Name = "Boston Symphony Orchestra & Seiji Ozawa" }
    { ArtistId = 230; Name = "Aaron Copland & London Symphony Orchestra" }
    { ArtistId = 231; Name = "Ton Koopman" }
    { ArtistId = 232; Name = "Sergei Prokofiev & Yuri Temirkanov" }
    { ArtistId = 233; Name = "Chicago Symphony Orchestra & Fritz Reiner" }
    { ArtistId = 234; Name = "Orchestra of The Age of Enlightenment" }
    { ArtistId = 236; Name = "James Levine" }
    { ArtistId = 237; Name = "Berliner Philharmoniker & Hans Rosbaud" }
    { ArtistId = 238; Name = "Maurizio Pollini" }
    { ArtistId = 240; Name = "Gustav Mahler" }
    { ArtistId = 242; Name = "Edo de Waart & San Francisco Symphony" }
    { ArtistId = 244; Name = "Choir Of Westminster Abbey & Simon Preston" }
    { ArtistId = 245; Name = "Michael Tilson Thomas & San Francisco Symphony" }
    { ArtistId = 247; Name = "The King's Singers" }
    { ArtistId = 248; Name = "Berliner Philharmoniker & Herbert Von Karajan" }
    { ArtistId = 250; Name = "Christopher O'Riley" }
    { ArtistId = 251; Name = "Fretwork" }
    { ArtistId = 252; Name = "Amy Winehouse" }
    { ArtistId = 253; Name = "Calexico" }
    { ArtistId = 255; Name = "Yehudi Menuhin" }
    { ArtistId = 258; Name = "Les Arts Florissants & William Christie" }
    { ArtistId = 259; Name = "The 12 Cellists of The Berlin Philharmonic" }
    { ArtistId = 260; Name = "Adrian Leaper & Doreen de Feis" }
    { ArtistId = 261; Name = "Roger Norrington, London Classical Players" }
    { ArtistId = 264; Name = "Kent Nagano and Orchestre de l'Opéra de Lyon" }
    { ArtistId = 265; Name = "Julian Bream" }
    { ArtistId = 266; Name = "Martin Roscoe" }
    { ArtistId = 267; Name = "Göteborgs Symfoniker & Neeme Järvi" }
    { ArtistId = 270; Name = "Gerald Moore" }
    { ArtistId = 271; Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" }
    { ArtistId = 274; Name = "Nash Ensemble" }
    { ArtistId = 276; Name = "Chic" }
    { ArtistId = 277; Name = "Anita Ward" }
    { ArtistId = 278; Name = "Donna Summer" }
  ]

let getAlbumsForGenre genreName (ctx : DbContext) : Album list =
  let genre = getGenres ctx |> List.tryFind (fun genre -> genre.Name = genreName)
  match genre with
    | None -> []
    | Some(genre) -> allAlbums |> List.filter (fun album -> album.GenreId = genre.GenreId)

let getAlbumsDetails (ctx : DbContext) : AlbumDetails list =
  [
    { AlbumId = 1; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "For Those About To Rock We Salute You"; Artist = "AC/DC"; Genre = "Rock" }
    { AlbumId = 2; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Let There Be Rock"; Artist = "AC/DC"; Genre = "Rock" }
    { AlbumId = 3; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Greatest Hits"; Artist = "Lenny Kravitz"; Genre = "Rock" }
    { AlbumId = 4; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Misplaced Childhood"; Artist = "Marillion"; Genre = "Rock" }
    { AlbumId = 5; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Best Of Men At Work"; Artist = "Men At Work"; Genre = "Rock" }
    { AlbumId = 7; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Nevermind"; Artist = "Nirvana"; Genre = "Rock" }
    { AlbumId = 8; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Compositores"; Artist = "O Terço"; Genre = "Rock" }
    { AlbumId = 9; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bark at the Moon (Remastered)"; Artist = "Ozzy Osbourne"; Genre = "Rock" }
    { AlbumId = 10; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Blizzard of Ozz"; Artist = "Ozzy Osbourne"; Genre = "Rock" }
    { AlbumId = 11; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Diary of a Madman (Remastered)"; Artist = "Ozzy Osbourne"; Genre = "Rock" }
    { AlbumId = 12; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "No More Tears (Remastered)"; Artist = "Ozzy Osbourne"; Genre = "Rock" }
    { AlbumId = 13; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Speak of the Devil"; Artist = "Ozzy Osbourne"; Genre = "Rock" }
    { AlbumId = 14; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Walking Into Clarksdale"; Artist = "Page & Plant"; Genre = "Rock" }
    { AlbumId = 15; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Beast Live"; Artist = "Paul D'Ianno"; Genre = "Rock" }
    { AlbumId = 16; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Live On Two Legs [Live]"; Artist = "Pearl Jam"; Genre = "Rock" }
    { AlbumId = 17; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Riot Act"; Artist = "Pearl Jam"; Genre = "Rock" }
    { AlbumId = 18; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Ten"; Artist = "Pearl Jam"; Genre = "Rock" }
    { AlbumId = 19; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Vs."; Artist = "Pearl Jam"; Genre = "Rock" }
    { AlbumId = 20; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Dark Side Of The Moon"; Artist = "Pink Floyd"; Genre = "Rock" }
    { AlbumId = 21; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "New Adventures In Hi-Fi"; Artist = "R.E.M."; Genre = "Rock" }
    { AlbumId = 22; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Raul Seixas"; Artist = "Raul Seixas"; Genre = "Rock" }
    { AlbumId = 23; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "By The Way"; Artist = "Red Hot Chili Peppers"; Genre = "Rock" }
    { AlbumId = 24; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Californication"; Artist = "Red Hot Chili Peppers"; Genre = "Rock" }
    { AlbumId = 25; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Retrospective I (1974-1980)"; Artist = "Rush"; Genre = "Rock" }
    { AlbumId = 26; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Maquinarama"; Artist = "Skank"; Genre = "Rock" }
    { AlbumId = 27; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "O Samba Poconé"; Artist = "Skank"; Genre = "Rock" }
    { AlbumId = 28; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "A-Sides"; Artist = "Soundgarden"; Genre = "Rock" }
    { AlbumId = 29; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Core"; Artist = "Stone Temple Pilots"; Genre = "Rock" }
    { AlbumId = 30; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "[1997] Black Light Syndrome"; Artist = "Terry Bozzio, Tony Levin & Steve Stevens"; Genre = "Rock" }
    { AlbumId = 31; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Beyond Good And Evil"; Artist = "The Cult"; Genre = "Rock" }
    { AlbumId = 33; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Doors"; Artist = "The Doors"; Genre = "Rock" }
    { AlbumId = 34; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Police Greatest Hits"; Artist = "The Police"; Genre = "Rock" }
    { AlbumId = 35; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Hot Rocks, 1964-1971 (Disc 1)"; Artist = "The Rolling Stones"; Genre = "Rock" }
    { AlbumId = 36; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "No Security"; Artist = "The Rolling Stones"; Genre = "Rock" }
    { AlbumId = 37; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Voodoo Lounge"; Artist = "The Rolling Stones"; Genre = "Rock" }
    { AlbumId = 38; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "My Generation - The Very Best Of The Who"; Artist = "The Who"; Genre = "Rock" }
    { AlbumId = 39; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Achtung Baby"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 40; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "B-Sides 1980-1990"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 41; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "How To Dismantle An Atomic Bomb"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 42; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Pop"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 43; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Rattle And Hum"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 44; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Best Of 1980-1990"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 45; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "War"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 46; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Zooropa"; Artist = "U2"; Genre = "Rock" }
    { AlbumId = 47; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Diver Down"; Artist = "Van Halen"; Genre = "Rock" }
    { AlbumId = 48; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Best Of Van Halen, Vol. I"; Artist = "Van Halen"; Genre = "Rock" }
    { AlbumId = 49; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Van Halen III"; Artist = "Van Halen"; Genre = "Rock" }
    { AlbumId = 50; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Van Halen"; Artist = "Van Halen"; Genre = "Rock" }
    { AlbumId = 51; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Contraband"; Artist = "Velvet Revolver"; Genre = "Rock" }
    { AlbumId = 52; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Un-Led-Ed"; Artist = "Dread Zeppelin"; Genre = "Rock" }
    { AlbumId = 54; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Balls to the Wall"; Artist = "Accept"; Genre = "Rock" }
    { AlbumId = 55; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Restless and Wild"; Artist = "Accept"; Genre = "Rock" }
    { AlbumId = 56; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Every Kind of Light"; Artist = "The Posies"; Genre = "Rock" }
    { AlbumId = 57; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "BBC Sessions [Disc 1] [Live]"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 58; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "BBC Sessions [Disc 2] [Live]"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 59; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Coda"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 60; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Houses Of The Holy"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 61; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "In Through The Out Door"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 62; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "IV"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 63; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Led Zeppelin I"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 64; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Led Zeppelin II"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 65; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Led Zeppelin III"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 66; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Physical Graffiti [Disc 1]"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 67; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Physical Graffiti [Disc 2]"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 68; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Presence"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 69; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Song Remains The Same (Disc 1)"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 70; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Song Remains The Same (Disc 2)"; Artist = "Led Zeppelin"; Genre = "Rock" }
    { AlbumId = 71; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bongo Fury"; Artist = "Frank Zappa & Captain Beefheart"; Genre = "Rock" }
    { AlbumId = 72; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Big Ones"; Artist = "Aerosmith"; Genre = "Rock" }
    { AlbumId = 73; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Jagged Little Pill"; Artist = "Alanis Morissette"; Genre = "Rock" }
    { AlbumId = 74; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Facelift"; Artist = "Alice In Chains"; Genre = "Rock" }
    { AlbumId = 75; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Greatest Hits I"; Artist = "Queen"; Genre = "Rock" }
    { AlbumId = 76; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Greatest Hits II"; Artist = "Queen"; Genre = "Rock" }
    { AlbumId = 77; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "News Of The World"; Artist = "Queen"; Genre = "Rock" }
    { AlbumId = 78; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Greatest Kiss"; Artist = "Kiss"; Genre = "Rock" }
    { AlbumId = 79; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Unplugged [Live]"; Artist = "Kiss"; Genre = "Rock" }
    { AlbumId = 80; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Into The Light"; Artist = "David Coverdale"; Genre = "Rock" }
    { AlbumId = 81; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Come Taste The Band"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 82; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Deep Purple In Rock"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 83; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Fireball"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 84; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Machine Head"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 85; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "MK III The Final Concerts [Disc 1]"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 86; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Purpendicular"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 87; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Slaves And Masters"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 88; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Stormbringer"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 89; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Battle Rages On"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 90; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Final Concerts (Disc 2)"; Artist = "Deep Purple"; Genre = "Rock" }
    { AlbumId = 91; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Santana - As Years Go By"; Artist = "Santana"; Genre = "Rock" }
    { AlbumId = 92; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Santana Live"; Artist = "Santana"; Genre = "Rock" }
    { AlbumId = 93; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Supernatural"; Artist = "Santana"; Genre = "Rock" }
    { AlbumId = 94; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Chronicle, Vol. 1"; Artist = "Creedence Clearwater Revival"; Genre = "Rock" }
    { AlbumId = 95; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Chronicle, Vol. 2"; Artist = "Creedence Clearwater Revival"; Genre = "Rock" }
    { AlbumId = 96; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Audioslave"; Artist = "Audioslave"; Genre = "Rock" }
    { AlbumId = 97; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "King For A Day Fool For A Lifetime"; Artist = "Faith No More"; Genre = "Rock" }
    { AlbumId = 98; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "In Your Honor [Disc 1]"; Artist = "Foo Fighters"; Genre = "Rock" }
    { AlbumId = 99; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "In Your Honor [Disc 2]"; Artist = "Foo Fighters"; Genre = "Rock" }
    { AlbumId = 100; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Colour And The Shape"; Artist = "Foo Fighters"; Genre = "Rock" }
    { AlbumId = 101; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Appetite for Destruction"; Artist = "Guns N' Roses"; Genre = "Rock" }
    { AlbumId = 102; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Use Your Illusion I"; Artist = "Guns N' Roses"; Genre = "Rock" }
    { AlbumId = 103; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "A Matter of Life and Death"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 104; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Brave New World"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 105; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Fear Of The Dark"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 106; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Live At Donington 1992 (Disc 1)"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 107; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Live At Donington 1992 (Disc 2)"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 108; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Rock In Rio [CD2]"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 109; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Number of The Beast"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 110; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The X Factor"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 111; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Virtual XI"; Artist = "Iron Maiden"; Genre = "Rock" }
    { AlbumId = 112; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Emergency On Planet Earth"; Artist = "Jamiroquai"; Genre = "Rock" }
    { AlbumId = 113; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Are You Experienced?"; Artist = "Jimi Hendrix"; Genre = "Rock" }
    { AlbumId = 114; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Surfing with the Alien (Remastered)"; Artist = "Joe Satriani"; Genre = "Rock" }
    { AlbumId = 115; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Best of Beethoven"; Artist = "Nicolaus Esterhazy Sinfonia"; Genre = "Classical" }
    { AlbumId = 119; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Pachelbel: Canon & Gigue"; Artist = "English Concert & Trevor Pinnock"; Genre = "Classical" }
    { AlbumId = 122; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bach: Goldberg Variations"; Artist = "Wilhelm Kempff"; Genre = "Classical" }
    { AlbumId = 123; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bach: The Cello Suites"; Artist = "Yo-Yo Ma"; Genre = "Classical" }
    { AlbumId = 124; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Handel: The Messiah (Highlights)"; Artist = "Scholars Baroque Ensemble"; Genre = "Classical" }
    { AlbumId = 128; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Haydn: Symphonies 99 - 104"; Artist = "Royal Philharmonic Orchestra & Sir Thomas Beecham"; Genre = "Classical" }
    { AlbumId = 130; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "A Soprano Inspired"; Artist = "Britten Sinfonia, Ivor Bolton & Lesley Garrett"; Genre = "Classical" }
    { AlbumId = 132; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Wagner: Favourite Overtures"; Artist = "Sir Georg Solti & Wiener Philharmoniker"; Genre = "Classical" }
    { AlbumId = 134; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Tchaikovsky: The Nutcracker"; Artist = "London Symphony Orchestra & Sir Charles Mackerras"; Genre = "Classical" }
    { AlbumId = 135; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Last Night of the Proms"; Artist = "Barry Wordsworth & BBC Concert Orchestra"; Genre = "Classical" }
    { AlbumId = 138; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Respighi:Pines of Rome"; Artist = "Eugene Ormandy"; Genre = "Classical" }
    { AlbumId = 139; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Strauss: Waltzes"; Artist = "Eugene Ormandy"; Genre = "Classical" }
    { AlbumId = 140; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Carmina Burana"; Artist = "Boston Symphony Orchestra & Seiji Ozawa"; Genre = "Classical" }
    { AlbumId = 141; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "A Copland Celebration, Vol. I"; Artist = "Aaron Copland & London Symphony Orchestra"; Genre = "Classical" }
    { AlbumId = 142; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bach: Toccata & Fugue in D Minor"; Artist = "Ton Koopman"; Genre = "Classical" }
    { AlbumId = 143; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Prokofiev: Symphony No.1"; Artist = "Sergei Prokofiev & Yuri Temirkanov"; Genre = "Classical" }
    { AlbumId = 144; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Scheherazade"; Artist = "Chicago Symphony Orchestra & Fritz Reiner"; Genre = "Classical" }
    { AlbumId = 145; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bach: The Brandenburg Concertos"; Artist = "Orchestra of The Age of Enlightenment"; Genre = "Classical" }
    { AlbumId = 147; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Mascagni: Cavalleria Rusticana"; Artist = "James Levine"; Genre = "Classical" }
    { AlbumId = 148; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Sibelius: Finlandia"; Artist = "Berliner Philharmoniker & Hans Rosbaud"; Genre = "Classical" }
    { AlbumId = 152; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Adams, John: The Chairman Dances"; Artist = "Edo de Waart & San Francisco Symphony"; Genre = "Classical" }
    { AlbumId = 154; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Berlioz: Symphonie Fantastique"; Artist = "Michael Tilson Thomas & San Francisco Symphony"; Genre = "Classical" }
    { AlbumId = 155; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Prokofiev: Romeo & Juliet"; Artist = "Michael Tilson Thomas & San Francisco Symphony"; Genre = "Classical" }
    { AlbumId = 157; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "English Renaissance"; Artist = "The King's Singers"; Genre = "Classical" }
    { AlbumId = 159; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Mozart: Symphonies Nos. 40 & 41"; Artist = "Berliner Philharmoniker & Herbert Von Karajan"; Genre = "Classical" }
    { AlbumId = 161; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "SCRIABIN: Vers la flamme"; Artist = "Christopher O'Riley"; Genre = "Classical" }
    { AlbumId = 163; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Bartok: Violin & Viola Concertos"; Artist = "Yehudi Menuhin"; Genre = "Classical" }
    { AlbumId = 166; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "South American Getaway"; Artist = "The 12 Cellists of The Berlin Philharmonic"; Genre = "Classical" }
    { AlbumId = 167; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Górecki: Symphony No. 3"; Artist = "Adrian Leaper & Doreen de Feis"; Genre = "Classical" }
    { AlbumId = 168; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Purcell: The Fairy Queen"; Artist = "Roger Norrington, London Classical Players"; Genre = "Classical" }
    { AlbumId = 171; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Weill: The Seven Deadly Sins"; Artist = "Kent Nagano and Orchestre de l'Opéra de Lyon"; Genre = "Classical" }
    { AlbumId = 173; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Szymanowski: Piano Works, Vol. 1"; Artist = "Martin Roscoe"; Genre = "Classical" }
    { AlbumId = 174; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Nielsen: The Six Symphonies"; Artist = "Göteborgs Symfoniker & Neeme Järvi"; Genre = "Classical" }
    { AlbumId = 177; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Mozart: Chamber Music"; Artist = "Nash Ensemble"; Genre = "Classical" }
    { AlbumId = 178; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Best Of Billy Cobham"; Artist = "Billy Cobham"; Genre = "Jazz" }
    { AlbumId = 179; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Quiet Songs"; Artist = "Aisha Duo"; Genre = "Jazz" }
    { AlbumId = 180; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Worlds"; Artist = "Aaron Goldberg"; Genre = "Jazz" }
    { AlbumId = 181; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Quanta Gente Veio ver--Bônus De Carnaval"; Artist = "Gilberto Gil"; Genre = "Jazz" }
    { AlbumId = 182; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Heart of the Night"; Artist = "Spyro Gyra"; Genre = "Jazz" }
    { AlbumId = 183; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Morning Dance"; Artist = "Spyro Gyra"; Genre = "Jazz" }
    { AlbumId = 184; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Warner 25 Anos"; Artist = "Antônio Carlos Jobim"; Genre = "Jazz" }
    { AlbumId = 185; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Miles Ahead"; Artist = "Miles Davis"; Genre = "Jazz" }
    { AlbumId = 186; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Essential Miles Davis [Disc 1]"; Artist = "Miles Davis"; Genre = "Jazz" }
    { AlbumId = 187; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Essential Miles Davis [Disc 2]"; Artist = "Miles Davis"; Genre = "Jazz" }
    { AlbumId = 188; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Outbreak"; Artist = "Dennis Chambers"; Genre = "Jazz" }
    { AlbumId = 189; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Blue Moods"; Artist = "Incognito"; Genre = "Jazz" }
    { AlbumId = 190; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Greatest Hits"; Artist = "Lenny Kravitz"; Genre = "Metal" }
    { AlbumId = 191; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Ace Of Spades"; Artist = "Motörhead"; Genre = "Metal" }
    { AlbumId = 192; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Motley Crue Greatest Hits"; Artist = "Mötley Crüe"; Genre = "Metal" }
    { AlbumId = 193; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Alcohol Fueled Brewtality Live! [Disc 1]"; Artist = "Black Label Society"; Genre = "Metal" }
    { AlbumId = 194; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Alcohol Fueled Brewtality Live! [Disc 2]"; Artist = "Black Label Society"; Genre = "Metal" }
    { AlbumId = 195; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Tribute"; Artist = "Ozzy Osbourne"; Genre = "Metal" }
    { AlbumId = 196; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Black Sabbath Vol. 4 (Remaster)"; Artist = "Black Sabbath"; Genre = "Metal" }
    { AlbumId = 197; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Black Sabbath"; Artist = "Black Sabbath"; Genre = "Metal" }
    { AlbumId = 198; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Mezmerize"; Artist = "System Of A Down"; Genre = "Metal" }
    { AlbumId = 199; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Chemical Wedding"; Artist = "Bruce Dickinson"; Genre = "Metal" }
    { AlbumId = 200; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "...And Justice For All"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 201; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Black Album"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 202; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Garage Inc. (Disc 1)"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 203; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Garage Inc. (Disc 2)"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 204; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Load"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 205; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Master Of Puppets"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 206; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "ReLoad"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 207; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Ride The Lightning"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 208; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "St. Anger"; Artist = "Metallica"; Genre = "Metal" }
    { AlbumId = 209; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Plays Metallica By Four Cellos"; Artist = "Apocalyptica"; Genre = "Metal" }
    { AlbumId = 210; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Faceless"; Artist = "Godsmack"; Genre = "Metal" }
    { AlbumId = 211; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Use Your Illusion II"; Artist = "Guns N' Roses"; Genre = "Metal" }
    { AlbumId = 212; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "A Real Dead One"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 213; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "A Real Live One"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 214; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Live After Death"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 215; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "No Prayer For The Dying"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 216; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Piece Of Mind"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 217; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Powerslave"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 218; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Rock In Rio [CD1]"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 219; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Rock In Rio [CD2]"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 220; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Seventh Son of a Seventh Son"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 221; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Somewhere in Time"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 222; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Number of The Beast"; Artist = "Iron Maiden"; Genre = "Metal" }
    { AlbumId = 223; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Living After Midnight"; Artist = "Judas Priest"; Genre = "Metal" }
    { AlbumId = 224; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Cake: B-Sides and Rarities"; Artist = "Cake"; Genre = "Alternative" }
    { AlbumId = 225; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Temple of the Dog"; Artist = "Temple of the Dog"; Genre = "Alternative" }
    { AlbumId = 226; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Carry On"; Artist = "Chris Cornell"; Genre = "Alternative" }
    { AlbumId = 227; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Carried to Dust (Bonus Track Version)"; Artist = "Calexico"; Genre = "Alternative" }
    { AlbumId = 228; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Revelations"; Artist = "Audioslave"; Genre = "Alternative" }
    { AlbumId = 229; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "In Step"; Artist = "Stevie Ray Vaughan & Double Trouble"; Genre = "Blues" }
    { AlbumId = 230; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Live [Disc 1]"; Artist = "The Black Crowes"; Genre = "Blues" }
    { AlbumId = 231; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Live [Disc 2]"; Artist = "The Black Crowes"; Genre = "Blues" }
    { AlbumId = 233; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Cream Of Clapton"; Artist = "Eric Clapton"; Genre = "Blues" }
    { AlbumId = 234; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Unplugged"; Artist = "Eric Clapton"; Genre = "Blues" }
    { AlbumId = 235; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Iron Maiden"; Artist = "Iron Maiden"; Genre = "Blues" }
    { AlbumId = 238; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Barulhinho Bom"; Artist = "Marisa Monte"; Genre = "Latin" }
    { AlbumId = 239; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Olodum"; Artist = "Olodum"; Genre = "Latin" }
    { AlbumId = 240; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Acústico MTV"; Artist = "Os Paralamas Do Sucesso"; Genre = "Latin" }
    { AlbumId = 241; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Arquivo II"; Artist = "Os Paralamas Do Sucesso"; Genre = "Latin" }
    { AlbumId = 242; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Arquivo Os Paralamas Do Sucesso"; Artist = "Os Paralamas Do Sucesso"; Genre = "Latin" }
    { AlbumId = 243; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Serie Sem Limite (Disc 1)"; Artist = "Tim Maia"; Genre = "Latin" }
    { AlbumId = 244; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Serie Sem Limite (Disc 2)"; Artist = "Tim Maia"; Genre = "Latin" }
    { AlbumId = 245; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Ao Vivo [IMPORT]"; Artist = "Zeca Pagodinho"; Genre = "Latin" }
    { AlbumId = 246; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Prenda Minha"; Artist = "Caetano Veloso"; Genre = "Latin" }
    { AlbumId = 247; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Sozinho Remix Ao Vivo"; Artist = "Caetano Veloso"; Genre = "Latin" }
    { AlbumId = 248; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Minha Historia"; Artist = "Chico Buarque"; Genre = "Latin" }
    { AlbumId = 249; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Afrociberdelia"; Artist = "Chico Science & Nação Zumbi"; Genre = "Latin" }
    { AlbumId = 250; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Da Lama Ao Caos"; Artist = "Chico Science & Nação Zumbi"; Genre = "Latin" }
    { AlbumId = 251; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Na Pista"; Artist = "Cláudio Zoli"; Genre = "Latin" }
    { AlbumId = 252; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Duos II"; Artist = "Luciana Souza/Romero Lubambo"; Genre = "Latin" }
    { AlbumId = 253; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Sambas De Enredo 2001"; Artist = "Various Artists"; Genre = "Latin" }
    { AlbumId = 254; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Vozes do MPB"; Artist = "Various Artists"; Genre = "Latin" }
    { AlbumId = 255; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Chill: Brazil (Disc 1)"; Artist = "Marcos Valle"; Genre = "Latin" }
    { AlbumId = 256; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Quanta Gente Veio Ver (Live)"; Artist = "Gilberto Gil"; Genre = "Latin" }
    { AlbumId = 257; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "The Best of Ed Motta"; Artist = "Ed Motta"; Genre = "Latin" }
    { AlbumId = 258; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Elis Regina-Minha História"; Artist = "Elis Regina"; Genre = "Latin" }
    { AlbumId = 259; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Milton Nascimento Ao Vivo"; Artist = "Milton Nascimento"; Genre = "Latin" }
    { AlbumId = 260; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Minas"; Artist = "Milton Nascimento"; Genre = "Latin" }
    { AlbumId = 261; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Jorge Ben Jor 25 Anos"; Artist = "Jorge Ben"; Genre = "Latin" }
    { AlbumId = 262; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Meus Momentos"; Artist = "Gonzaguinha"; Genre = "Latin" }
    { AlbumId = 263; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Chill: Brazil (Disc 2)"; Artist = "Antônio Carlos Jobim"; Genre = "Latin" }
    { AlbumId = 264; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Vinicius De Moraes"; Artist = "Vinícius De Moraes"; Genre = "Latin" }
    { AlbumId = 266; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Cássia Eller - Sem Limite [Disc 1]"; Artist = "Cássia Eller"; Genre = "Latin" }
    { AlbumId = 267; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Djavan Ao Vivo - Vol. 02"; Artist = "Djavan"; Genre = "Latin" }
    { AlbumId = 268; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Djavan Ao Vivo - Vol. 1"; Artist = "Djavan"; Genre = "Latin" }
    { AlbumId = 269; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Unplugged"; Artist = "Eric Clapton"; Genre = "Latin" }
    { AlbumId = 270; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Deixa Entrar"; Artist = "Falamansa"; Genre = "Latin" }
    { AlbumId = 271; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Roda De Funk"; Artist = "Funk Como Le Gusta"; Genre = "Latin" }
    { AlbumId = 272; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Jota Quest-1995"; Artist = "Jota Quest"; Genre = "Latin" }
    { AlbumId = 274; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Mais Do Mesmo"; Artist = "Legião Urbana"; Genre = "Latin" }
    { AlbumId = 275; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Greatest Hits"; Artist = "Lenny Kravitz"; Genre = "Reggae" }
    { AlbumId = 276; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "UB40 The Best Of - Volume Two [UK]"; Artist = "UB40"; Genre = "Reggae" }
    { AlbumId = 277; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Acústico MTV [Live]"; Artist = "Cidade Negra"; Genre = "Reggae" }
    { AlbumId = 278; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Cidade Negra - Hits"; Artist = "Cidade Negra"; Genre = "Reggae" }
    { AlbumId = 280; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Axé Bahia 2001"; Artist = "Various Artists"; Genre = "Pop" }
    { AlbumId = 281; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Frank"; Artist = "Amy Winehouse"; Genre = "Pop" }
    { AlbumId = 282; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Le Freak"; Artist = "Chic"; Genre = "Disco" }
    { AlbumId = 283; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "MacArthur Park Suite"; Artist = "Donna Summer"; Genre = "Disco" }
    { AlbumId = 284; AlbumArtUrl = "/placeholder.gif"; Price = 8.99M; Title = "Ring My Bell"; Artist = "Anita Ward"; Genre = "Disco" }
  ]

let getAlbumDetails id (ctx : DbContext) : AlbumDetails option =
  getAlbumsDetails ctx
  |> List.filter (fun album -> album.AlbumId = id)
  |> firstOrNone

let getBestSellers (ctx : DbContext) : BestSeller list  =
  []

let getAlbum id (ctx : DbContext) : Album option =
  allAlbums
  |> List.filter (fun album -> album.AlbumId = id)
  |> firstOrNone

let users =
  [
    { UserId = 1; UserName = "admin"; Email = "admin@example@com"; Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"; Role = "admin" }
  ]

let validateUser (username, password) (ctx : DbContext) : User option =
  users
  |> List.filter (fun user -> user.UserName = username && user.Password = password)
  |> firstOrNone

let getUser username (ctx : DbContext) : User option =
  users
  |> List.filter (fun user -> user.UserName = username)
  |> firstOrNone

let getCart cartId albumId (ctx : DbContext) : Cart option =
  None

let getCarts cartId (ctx : DbContext) : Cart list =
  []

let getCartsDetails cartId (ctx : DbContext) : CartDetails list =
  []

let createAlbum (artistId, genreId, price, title) (ctx : DbContext) =
  ()

let updateAlbum (album : Album) (artistId, genreId, price, title) (ctx : DbContext) =
  ()

let deleteAlbum (album : Album) (ctx : DbContext) =
  ()

let addToCart cartId albumId (ctx : DbContext)  =
  ()

let removeFromCart (cart : Cart) albumId (ctx : DbContext) =
  ()

let upgradeCarts (cartId : string, username :string) (ctx : DbContext) =
  ()

let newUser (username, password, email) (ctx : DbContext) =
  { UserId = 1; UserName = ""; Email = ""; Password = ""; Role = "" }

let placeOrder (username : string) (ctx : DbContext) =
  ()
