using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

public class EnemyConroller {

    public List<IEnemy> enemyArray { get; set; } = new List<IEnemy>();

    private Gel gel;
    private Bat bat;

    private int index;

    public void LoadContent(ContentManager content, SpriteBatch _spriteBatch, GraphicsDeviceManager _graphics)
    {
        Texture2D gelTexture = content.Load<Texture2D>("EnemySprites");
        GelSpriteFactory gelSpriteFactory = new GelSpriteFactory(gelTexture, _spriteBatch);
        Gel gel = new Gel(gelSpriteFactory, _graphics);
        enemyArray.Add(gel);

        Texture2D batTexture = content.Load<Texture2D>("EnemySprites");
        BatSpriteFactory batSpriteFactory = new BatSpriteFactory(batTexture, _spriteBatch);
        Bat bat = new Bat(batSpriteFactory, _graphics);
        enemyArray.Add(bat);

        Texture2D goriyaTexture = content.Load<Texture2D>("EnemySprites");
        GoriyaSpriteFactory goriyaSpriteFactory = new GoriyaSpriteFactory(goriyaTexture, _spriteBatch);
        Goriya goriya = new Goriya(goriyaSpriteFactory, _graphics);
        enemyArray.Add(goriya);

    }

    public void NextEnemy()
    {
        index++;
        if (index >= enemyArray.Count)
        {
            index = 0;
        }
    }

    public void PreviousEnemy()
    {
        index--;
        if (index < 0)
        {
            index = enemyArray.Count - 1;
        }
    }

    public EnemyConroller()
    {
        enemyArray = new List<IEnemy>();
    }

    public void Update(GameTime gameTime)
    {
        enemyArray[index].Update(gameTime);

    }

    public void Draw()
    {
        enemyArray[index].Draw();

    }











}

