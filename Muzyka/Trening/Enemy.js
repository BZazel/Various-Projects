Enemy.count = 0;
Enemy.all = [];
//
Enemy.setX = function()
{
	var LMarg = 100;
	var UMarg = 400;
	var x = 0;UMarg
	if (Hero.x < UMarg) { x = VAR.rand(Hero.x+LMarg, Hero.x+UMarg)}
	else if (Hero.x > VAR.W-UMarg) {x = VAR.rand(Hero.x-LMarg, Hero.x-UMarg)}
	else	
	{
		x = VAR.rand(0,1)?VAR.rand(Hero.x-UMarg,Hero.x-LMarg):VAR.rand(Hero.x+LMarg,Hero.x+UMarg);
	}	
	return x;
}
function Enemy ()
{
	Enemy.count ++;
	this.id = "Enemy_" + Enemy.count;
	// POPRAWIĆ  
	this.X = Enemy.setX();
	this.Y = VAR.rand(10,80);
	this.W = 50;
	this.H = 50;
	this.checked = false;
	this.time = Date.now();
	Enemy.all[this.id] = this;
}
Enemy.prototype.draw = function()
{
	Game.hit_ctx.fillStyle = 'red';
	Game.hit_ctx.fillRect(this.X,this.Y,this.W,this.H);
	Game.ctx.filStyle = 'grey';
	Game.ctx.fillRect(this.X,this.Y,this.W,this.H);
}
Enemy.prototype.hitTest = function(x,y)
{
	//Border obj check -------
	if(!(x+5 > this.X && x+5 < (this.X + this.W) && y+5 > this.Y && y+5 < (this.Y + this.H)))		
		return;
	// Hit canvas - fill 
	Game.hit_ctx.clearRect(this.X,this.Y,this.W,this.H);
	Game.hit_ctx.fillStyle = 'red';
	Game.hit_ctx.fillRect(this.X,this.Y,this.W,this.H);
	// Obj hit-test
	if(Game.hit_ctx.getImageData(x,y,1,1).data[0] == 255)
	{
		VAR.killTimes.push(Date.now()- this.time);
		console.log(" Kill Time: " + (Date.now() - this.time)) ;
		return true;
	}
	 
		return false;
}
Enemy.draw = function()
{
	for( var e in Enemy.all)
	{
		Enemy.all[e].draw();
	}
	
}
