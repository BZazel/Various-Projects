Enemy.count = 0;
Enemy.all = [];
//
function Enemy ()
{
	Enemy.count ++;
	this.id = "Enemy_" + Enemy.count;
	this.X = VAR.rand(0,VAR.W);
	this.Y = VAR.rand(0,50);
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
