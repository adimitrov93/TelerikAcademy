// First If statement
Potato potato;
//... 
if (potato != null)
{
    if(potato.HasBeenPeeled && !potato.IsRotten)
    {
        Cook(potato);
    }
}

// Second If statement
bool isValidX = MIN_X >= x && x <= MAX_X;
bool isValidY = MIN_Y >= y && y <= MAX_Y;

if (isValidX && isValidY && shouldVisitCell)
{
   VisitCell();
}