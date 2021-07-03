using UnityEngine;
using System.Collections;

public class GamePlay : MonoBehaviour {

	private bool isLeft;
	private bool isRight;
	private bool isUp;
	private bool isDown;
	private int gameStart;
	public GUIManager gm;
	private int time;
	private int timeReady;
	private int life;
	private int score;
	private int baris;
	private int kolom;
	private int getDot;
	//untuk generate item
	private int timeGenerateItem;
	private int tmpBaris;
	private int tmpKolom;
	
	//gameobject 3d
	private GameObject cube;
	private GameObject sphere;
	private GameObject dotAdd;
	private GameObject dotMinus;
	private GameObject cameraView;
	//maze 20 x 20
	//melakukan generate map by code
	private char [,] maze = new char[,]{
		{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
		{'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ','#','#',' ','#','#',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ','#','#',' ','#','#',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ','#','#',' ','#','#',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
		{'#',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ','#'},
		{'#',' ','#','#',' ','#','#',' ','#','#','#','#','#','#','#','#','#',' ','#','#',' ','#','#',' ','#'},
		{'#',' ','#','#',' ','#','#',' ','#','#','#','#','#','#','#','#','#',' ','#','#',' ','#','#',' ','#'},
		{'#',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ','#'},
		{'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ','#','#',' ','#','#',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ','#','#',' ','#','#',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ','#','#',' ','#','#',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ','#','#','#','#','#',' ',' ',' ',' ',' ','H',' ',' ',' ',' ',' ','#','#','#','#','#',' ','#'},
		{'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
		{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
	};
	private float x,y,z;
	private GameObject [] snake = new GameObject[200];
	private int panjangSnake;
	private int tmpBarisSnake;
	private int tmpKolomSnake;
	private bool crashed;
	private int [,] arahSnake = new int[,]{
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
	};
	// Use this for initialization
	void Start () {
		isLeft = false;
		isUp = true;
		isRight = false;
		isDown = false;
		crashed = false;
		timeGenerateItem = 0;
		gameStart = 0;
		time = 60;
		timeReady = 3;
		life = 3;
		score = 0;
		panjangSnake = 0;
		tmpBarisSnake = 0;
		tmpKolomSnake = 0;
		getDot = 0;
		gm.setTime(time);
		cube = GameObject.Find("Cube");
		sphere = GameObject.Find("Sphere");
		dotAdd = GameObject.Find("DotAdd");
		dotMinus = GameObject.Find("DotMinus");
		cameraView = GameObject.Find("Main Camera");
		generateMap();
		do{
			tmpBaris = Random.Range(0,19);
			tmpKolom = Random.Range(0,24);
		}while(maze[tmpBaris,tmpKolom] != ' ');
		maze[tmpBaris,tmpKolom] = '+';
		Instantiate(dotAdd,new Vector3(tmpKolom,-3f,(tmpBaris*-1)),Quaternion.identity);
		StartCoroutine(timePlay());
		StartCoroutine(checkReady());
		StartCoroutine(snakeMove());
		StartCoroutine(generateItem());
	}
	public void generateMap(){
		y = -3f;
		z = 0f;
		for(int i=0; i<20; i++){
			x = 0f;
			for(int j=0; j<25; j++){
				arahSnake[i,j] = 0;
				if(maze[i,j] == '#'){
					Instantiate(cube,new Vector3(x,y,z),Quaternion.identity);
				}else if(maze[i,j] == 'H'){
					baris = i;
					kolom = j;
					snake[panjangSnake] = (GameObject)Instantiate(sphere,new Vector3(x,y,z),Quaternion.identity);
					cameraView.transform.parent = snake[panjangSnake].transform;
					cameraView.transform.localPosition = new Vector3(snake[panjangSnake].transform.localPosition.x-11f,cameraView.transform.localPosition.y,0);
					panjangSnake++;
				}
				x = x + 1f;
			}
			z = z - 1f;
		}
	}
	public void GetDot(int type, float baris, float kolom){
		//jika yang didapat dot hijau
		if(type == 1){
			score = score + 10;
			gm.setScore(score);
		}
		//jika yang didapat dot merah
		else if(type == 2){
			score = 0;
			gm.setScore(score);
		}
	}
	IEnumerator generateItem(){
		while(true){
			if(gameStart == 1){
				timeGenerateItem++;
				if(timeGenerateItem == 10){
					timeGenerateItem = 0;
					do{
						tmpBaris = Random.Range(0,19);
						tmpKolom = Random.Range(0,24);
					}while(maze[tmpBaris,tmpKolom] != ' ');
					maze[tmpBaris,tmpKolom] = '-';
					Instantiate(dotMinus,new Vector3(tmpKolom,-3f,(tmpBaris*-1)),Quaternion.identity);
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}
	IEnumerator timePlay(){
		while(true){
			if(time > 0 && gameStart == 1){
				time--;
				gm.setTime(time);
			}
			if(time == 0){
				GameOver();
			}
			yield return new WaitForSeconds(1f);
		}
	}
	IEnumerator checkReady(){
		while(true){
			if(timeReady > 0){
				gm.respawnReady(timeReady);
				timeReady--;
			}else if(timeReady == 0){
				gm.unrespawnReady();
				gameStart = 1;
				timeReady = -1;
			}
			yield return new WaitForSeconds(1f);
		}
	}
	public void moveAllBody(){
		for(int i=0; i<panjangSnake-1; i++){
			tmpBarisSnake = (int)(snake[i].transform.localPosition.z*-1f);
			if(tmpBarisSnake < 0)tmpBarisSnake = tmpBarisSnake * -1;
			tmpKolomSnake = (int)snake[i].transform.localPosition.x;
			if(arahSnake[tmpBarisSnake,tmpKolomSnake] == 1){ //kiri
				maze[tmpBarisSnake,tmpKolomSnake] = ' ';
				maze[tmpBarisSnake,tmpKolomSnake-1] = 'H';
				if(tmpBarisSnake > 0)tmpBarisSnake = tmpBarisSnake * -1;
				snake[i].transform.localPosition = new Vector3((snake[i].transform.localPosition.x-1f),snake[i].transform.localPosition.y,snake[i].transform.localPosition.z);
			}else if(arahSnake[tmpBarisSnake,tmpKolomSnake] == 2){ //atas
				maze[tmpBarisSnake,tmpKolomSnake] = ' ';
				maze[tmpBarisSnake-1,tmpKolomSnake] = 'H';
				if(tmpBarisSnake > 0)tmpBarisSnake = tmpBarisSnake * -1;
				snake[i].transform.localPosition = new Vector3((snake[i].transform.localPosition.x),snake[i].transform.localPosition.y,(tmpBarisSnake+1f));
			}else if(arahSnake[tmpBarisSnake,tmpKolomSnake] == 3){ //bawah
				maze[tmpBarisSnake,tmpKolomSnake] = ' ';
				maze[tmpBarisSnake+1,tmpKolomSnake] = 'H';
				if(tmpBarisSnake > 0)tmpBarisSnake = tmpBarisSnake * -1;
				snake[i].transform.localPosition = new Vector3((snake[i].transform.localPosition.x),snake[i].transform.localPosition.y,(tmpBarisSnake-1f));
			}else if(arahSnake[tmpBarisSnake,tmpKolomSnake] == 4){ //kanan
				maze[tmpBarisSnake,tmpKolomSnake] = ' ';
				maze[tmpBarisSnake,tmpKolomSnake+1] = 'H';
				if(tmpBarisSnake > 0)tmpBarisSnake = tmpBarisSnake * -1;
				snake[i].transform.localPosition = new Vector3((snake[i].transform.localPosition.x+1f),snake[i].transform.localPosition.y,snake[i].transform.localPosition.z);
			}
		}
	}
	IEnumerator snakeMove(){
		while(true){
			if(gameStart == 1){
				//arah snake:
				//1 kiri
				//2 atas
				//3 bawah
				//4 kanan
				
				if(isUp == true){
					if(maze[baris-1,kolom] == '#' || maze[baris-1,kolom] == 'H'){
						crashed = true;
						life = life - 1;
						gm.setLife(life);
					}else{
						crashed = false;
						if(maze[baris-1,kolom] == '+'){
							getDot = 1;
							snake[panjangSnake] = (GameObject)Instantiate(sphere,new Vector3(kolom,-3f,(baris-1)*-1),Quaternion.identity);
							cameraView.transform.parent = snake[panjangSnake].transform;
							arahSnake[baris,kolom] = 2;
							maze[baris-1,kolom] = 'H';
							baris = baris - 1;
							panjangSnake++;
							do{
								tmpBaris = Random.Range(0,19);
								tmpKolom = Random.Range(0,24);
							}while(maze[tmpBaris,tmpKolom] != ' ');
							maze[tmpBaris,tmpKolom] = '+';
							Instantiate(dotAdd,new Vector3(tmpKolom,-3f,(tmpBaris*-1)),Quaternion.identity);
						}else{
							if(panjangSnake == 1){
								arahSnake[baris,kolom] = 0;
								maze[baris,kolom] = ' ';
							}
							getDot = 0;
							arahSnake[baris,kolom] = 2;
							baris = baris - 1;
							maze[baris,kolom] = 'H';
							snake[panjangSnake-1].transform.localPosition = new Vector3(snake[panjangSnake-1].transform.localPosition.x,snake[panjangSnake-1].transform.localPosition.y,snake[panjangSnake-1].transform.localPosition.z+1);
						}
					}
				}else if(isDown == true){
					if(maze[baris+1,kolom] == '#'  || maze[baris+1,kolom] == 'H'){
						crashed = true;
						life = life - 1;
						gm.setLife(life);
					}else{
						crashed = false;
						if(maze[baris+1,kolom] == '+'){
							getDot = 1;
							snake[panjangSnake] = (GameObject)Instantiate(sphere,new Vector3(kolom,-3f,(baris+1)*-1),Quaternion.identity);
							cameraView.transform.parent = snake[panjangSnake].transform;
							arahSnake[baris,kolom] = 3;
							maze[baris+1,kolom] = 'H';
							baris = baris + 1;
							panjangSnake++;
							do{
								tmpBaris = Random.Range(0,19);
								tmpKolom = Random.Range(0,24);
							}while(maze[tmpBaris,tmpKolom] != ' ');
							maze[tmpBaris,tmpKolom] = '+';
							Instantiate(dotAdd,new Vector3(tmpKolom,-3f,(tmpBaris*-1)),Quaternion.identity);
						}else{
							if(panjangSnake == 1){
								arahSnake[baris,kolom] = 0;
								maze[baris,kolom] = ' ';
							}
							getDot = 0;
							arahSnake[baris,kolom] = 3;
							baris = baris + 1;
							maze[baris,kolom] = 'H';
							snake[panjangSnake-1].transform.localPosition = new Vector3(snake[panjangSnake-1].transform.localPosition.x,snake[panjangSnake-1].transform.localPosition.y,snake[panjangSnake-1].transform.localPosition.z-1);
						}
					}
				}else if(isLeft == true){
					if(maze[baris,kolom-1] == '#'  || maze[baris,kolom-1] == 'H'){
						crashed = true;
						life = life - 1;
						gm.setLife(life);
					}else{
						crashed = false;
						if(maze[baris,kolom-1] == '+'){
							getDot = 1;
							snake[panjangSnake] = (GameObject)Instantiate(sphere,new Vector3(kolom-1,-3f,baris*-1),Quaternion.identity);
							cameraView.transform.parent = snake[panjangSnake].transform;
							arahSnake[baris,kolom] = 1;
							maze[baris,kolom-1] = 'H';
							kolom = kolom - 1;
							panjangSnake++;
							do{
								tmpBaris = Random.Range(0,19);
								tmpKolom = Random.Range(0,24);
							}while(maze[tmpBaris,tmpKolom] != ' ');
							maze[tmpBaris,tmpKolom] = '+';
							Instantiate(dotAdd,new Vector3(tmpKolom,-3f,(tmpBaris*-1)),Quaternion.identity);
						}else{
							if(panjangSnake == 1){
								arahSnake[baris,kolom] = 0;
								maze[baris,kolom] = ' ';
							}
							getDot = 0;
							arahSnake[baris,kolom] = 1;
							kolom = kolom - 1;
							maze[baris,kolom] = 'H';
							snake[panjangSnake-1].transform.localPosition = new Vector3(snake[panjangSnake-1].transform.localPosition.x-1,snake[panjangSnake-1].transform.localPosition.y,snake[panjangSnake-1].transform.localPosition.z);
						}
					}
				}else if(isRight == true){
					if(maze[baris,kolom+1] == '#'  || maze[baris,kolom+1] == 'H'){
						crashed = true;
						life = life - 1;
						gm.setLife(life);
					}else{
						crashed = false;
						if(maze[baris,kolom+1] == '+'){
							getDot = 1;
							snake[panjangSnake] = (GameObject)Instantiate(sphere,new Vector3(kolom+1,-3f,baris*-1),Quaternion.identity);
							cameraView.transform.parent = snake[panjangSnake].transform;
							arahSnake[baris,kolom] = 4;
							maze[baris,kolom+1] = 'H';
							kolom = kolom + 1;
							panjangSnake++;
							do{
								tmpBaris = Random.Range(0,19);
								tmpKolom = Random.Range(0,24);
							}while(maze[tmpBaris,tmpKolom] != ' ');
							maze[tmpBaris,tmpKolom] = '+';
							Instantiate(dotAdd,new Vector3(tmpKolom,-3f,(tmpBaris*-1)),Quaternion.identity);
						}else{
							if(panjangSnake == 1){
								arahSnake[baris,kolom] = 0;
								maze[baris,kolom] = ' ';
							}
							getDot = 0;
							arahSnake[baris,kolom] = 4;
							kolom = kolom + 1;
							maze[baris,kolom] = 'H';
							snake[panjangSnake-1].transform.localPosition = new Vector3(snake[panjangSnake-1].transform.localPosition.x+1,snake[panjangSnake-1].transform.localPosition.y,snake[panjangSnake-1].transform.localPosition.z);
						}
					}
				}
				if(getDot == 0 && !crashed){
					moveAllBody();
				}
				if(life == 0)GameOver();
			}
			yield return new WaitForSeconds(0.25f);
		}
	}
	public void GameOver(){
		gameStart = 0;
		gm.respawnGameOver(score);
	}
	public void setAllFalse(){
		isLeft = false;
		isRight = false;
		isUp = false;
		isDown = false;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			if(gameStart == 1){
				gameStart = 2;
				gm.PauseGame(life,time,score);
			}else if(gameStart == 2){
				gameStart = 3;
				timeReady = 3;
				gm.UnpauseGame();
			}
		}else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
			if(panjangSnake > 1){
				if(isRight == false){
					setAllFalse();
					isLeft = true;
				}
			}else{
				setAllFalse();
				isLeft = true;
			}
		}else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
			if(panjangSnake > 1){
				if(isLeft == false){
					setAllFalse();
					isRight = true;
				}
			}else{
				setAllFalse();
				isRight = true;
			}
		}else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
			if(panjangSnake > 1){
				if(isDown == false){
					setAllFalse();
					isUp = true;
				}
			}else{
				setAllFalse();
				isUp = true;
			}
		}else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
			if(panjangSnake > 1){
				if(isUp == false){
					setAllFalse();
					isDown = true;
				}
			}else{
				setAllFalse();
				isDown = true;
			}
		}
	}
}
