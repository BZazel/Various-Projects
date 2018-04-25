//Initialization
window.onload = function()
{
	//Preloader
	Game.init();
	//console.log("Game -> start");
}
VAR = {
	fps:60,
	W:0,
	H:0,
	scale:1.0,
	lastTime:0,
	times:[],
	rand:function(min,max)
	{
		return Math.floor(Math.random()*(max-min+1))+min;
	}
}
//
Game = { 
	init:function()
	{
		Game.canvas = document.createElement('canvas');
		Game.ctx = Game.canvas.getContext('2d');
		//
		Game.hit_canvas = document.createElement('canvas');
		Game.hit_ctx = Game.hit_canvas.getContext('2d');
		Game.hit_ctx.fillStyle = 'red';
		//
		Game.layout();
		//
		window.addEventListener('resize',Game.layout,false);
		window.addEventListener('keydown',Game.onKey,false);
		window.addEventListener('keyup',Game.onKey,false);
		//
		//document.body.appendChild(Game.hit_canvas);	
		document.body.appendChild(Game.canvas);
		//
		Game.hero = new Hero();
		Game.enemy = new Enemy();
		Game.animationLoop();


	},
	layout:function()
	{
	VAR.W = window.innerWidth;
	VAR.H = window.innerHeight;
	//
	Game.canvas.width = VAR.W;
	Game.canvas.height = VAR.H;
	//
	Game.hit_canvas.width = VAR.W;
	Game.hit_canvas.height = VAR.H;
	// --------------------------
	//console.log("Layout-> set");
	},
	onKey:function(ev)

	{
	if(!((ev.keyCode >=37 && ev.keyCode <= 40) || ev.keyCode == 32) )
			return;
		if(!Game['key_'+ev.keyCode] && ev.type == 'keydown')
		{		
			for(i=37;i<=40;i++){
				if(i!=ev.keyCode){Game['key_'+i]=false;}
			}
			Game['key_'+ev.keyCode] = true;
			Game.hero.update();
			if (ev.keyCode == 32) {
				Game.hero.fire();
			}
		}
		else if(ev.type == 'keyup')
		{
			Game['key_' + ev.keyCode] = false
			Game.hero.update();
		}

	},
	timeCount:function ()
	{
		for(var e in Enemy.all)
		{
			if(Enemy.all[e].checked == true)
				break;

			if(Game.hero.X < Enemy.all[e].X)
			{
				
				if(Game.key_39)
				{

					VAR.times.push(Date.now() - Enemy.all[e].time);
					//
					Enemy.all[e].checked = true;
					//
					console.log((Date.now() - Enemy.all[e].time))
				}
			}
			else if( Game.hero.X > Enemy.all[e].X)
			{	
				if(Game.key_37)
				{
					VAR.times.push(Date.now() - Enemy.all[e].time);
					//
					Enemy.all[e].checked = true;
					//
					console.log((Date.now() - Enemy.all[e].time))
				}
			}
		
		}
 	},
	animationLoop:function(time)
	{
		requestAnimationFrame( Game.animationLoop );
		if (time - VAR.lastTime >=1000/VAR.fps) {
						
			VAR.lastTime = time;
			Game.timeCount();
			//Game.hit_ctx.clearRect(0,0,VAR.W, VAR.H);
			Game.ctx.clearRect(0,0,VAR.W, VAR.H);
			Game.hero.draw();
			//DRAW ++=========
			Enemy.draw();
			Shot.draw();
		}
	}
}