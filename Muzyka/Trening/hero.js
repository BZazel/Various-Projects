Hero.count = 0;
//
Hero.x ;
Hero.y ;
function Hero ()
{
	if(Hero.count !=0)
		return;

	Hero.count++;
	this.state = "stay";

	this.width = 50;
	this.height = 50;
	this.X = VAR.W/2-25;
	this.Y = VAR.H - 60;
	Hero.x = this.X;
	Hero.y = this.Y;

}

Hero.prototype.draw = function()
{	
	//Moving ---
	if(this.state == "go_left" && this.X > 0) {this.X-=15;}

	else if(this.state == "go_right" && this.X+this.width < VAR.W)
		{this.X+=25;}
	//----------
	Hero.x = this.X;
	Hero.y = this.Y;

	Game.ctx.fillRect(this.X,this.Y,50,50);
	Game.ctx.fillStyle = "#457F77";

}
//
Hero.prototype.fire = function()
{
	
	new Shot(this.X,this.Y,this.width,this.height);
	
}
//
Hero.prototype.update = function()
{
	if(Game.key_37){this.state = "go_left";}
	else if(Game.key_39){this.state = "go_right";}
	else 
	{
		this.state = 'stay';
	}			
}