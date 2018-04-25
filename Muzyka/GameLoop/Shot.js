Shot.count = 0;
Shot.all = [];  
Shot.box1 = document.getElementById("box1");
Shot.box2 = document.getElementById("box2");
Shot.box3 = document.getElementById("box3");

function Shot (x,y,w,h)
{	
	Shot.count ++;
	this.id = "Shot_" + Shot.count
	this.x = x + w/2 -2.5;
	this.y = y;
	this.w = w;
	this.h = h;
	 Shot.all[this.id] = this;

}
Shot.prototype.draw = function()
{
	Shot.box1.textContent = "Shot x: " + this.x;
	Shot.box2.textContent = "Shot y: "	+ this.y;

	if (this.y < 0)
		return;
	
		//console.log(this.id + 'has been drawn');


 		Game.ctx.fillRect(this.x,this.y,10,10);	

 		this.y -=45;
 	
}
Shot.draw = function()
{

	for (var shot in Shot.all)
	{
		for (var enemy in Enemy.all)
		{
			if(Enemy.all[enemy].hitTest(Shot.all[shot].x,Shot.all[shot].y))
			{
				
				delete Enemy.all[enemy];
				new Enemy();
				delete Shot.all[shot];

					break;
			}
		}
	}


	for (var s in Shot.all)
	{
		Shot.all[s].draw();
	}
}

