﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Hero { Aria, Bayl, Xaine, Yazir, Null };
public enum Action { Utility, Ultimate, Normal, Special, Null };
public enum Direction { DOWN, RIGHT, LEFT, UP, DESELECT, NONE };

public class PlayerController : MonoBehaviour{
    private Hero heroSelector;
    private Action actionSelector;
    public Text HeroText;
    public CharacterAttributes characterAttributes;

    GameObject AriaObject;
    GameObject BaylObject;
    GameObject XaineObject;
    GameObject YazirObject;

    Vector2 centerPosition;

    GameObject AriaHaste;
    GameObject BaylHaste;
    GameObject XaineHaste;
    GameObject YazirHaste;

    void Awake()
    {
        AriaObject = GameObject.Find("Aria");
        BaylObject = GameObject.Find("Bayl");
        XaineObject = GameObject.Find("Xaine");
        YazirObject = GameObject.Find("Yazir");
        centerPosition = new Vector2(4f, -1.3f);
        float xOffset = 2.8f;
        float yOffset = 1.3f;
        Vector2 AriaPosition = new Vector2(centerPosition.x, centerPosition.y - yOffset);
        Vector2 BaylPosition = new Vector2(centerPosition.x + xOffset, centerPosition.y);
        Vector2 XainePosition = new Vector2(centerPosition.x - xOffset, centerPosition.y);
        Vector2 YazirPosition = new Vector2(centerPosition.x, centerPosition.y + yOffset);
        AriaObject.GetComponent<AriaScript>().getHeroClass().setPosition(AriaPosition);
        BaylObject.GetComponent<BaylScript>().getHeroClass().setPosition(BaylPosition);
        XaineObject.GetComponent<XaineScript>().getHeroClass().setPosition(XainePosition);
        YazirObject.GetComponent<YazirScript>().getHeroClass().setPosition(YazirPosition);
        AriaObject.transform.position = AriaPosition;
        BaylObject.transform.position = BaylPosition;
        XaineObject.transform.position = XainePosition;
        YazirObject.transform.position = YazirPosition;
    }

    void Start()
    {
        resetSelectors();
    }

    void Update()
    {
        getInput(HeroText);
    }

    public void getInput(Text DamageText)
    {
        Direction direction = getDirection();
        if (direction == Direction.DESELECT)
        {
            resetSelectors();
            DamageText.text = "";
            return;
        }
        if (heroSelector == Hero.Null)
            heroSelector = selectHero(direction);
        else if (actionSelector == Action.Null)
            actionSelector = selectAction(direction);
        if (heroSelector != Hero.Null && actionSelector != Action.Null)
        {
            Test(HeroText);
            resetSelectors();
        }
    }

    Hero selectHero(Direction direction)
    {
        switch(direction)
        {
            case Direction.DOWN:
                return Hero.Aria;
            case Direction.RIGHT:
                return Hero.Bayl;
            case Direction.LEFT:
                return Hero.Xaine;
            case Direction.UP:
                return Hero.Yazir;
            default:
                return Hero.Null;
        }
    }

    Action selectAction(Direction direction)
    {
        switch(direction)
        {
            case Direction.DOWN:
                return Action.Utility;
            case Direction.RIGHT:
                return Action.Ultimate;
            case Direction.LEFT:
                return Action.Normal;
            case Direction.UP:
                return Action.Special;
            default:
                return Action.Null;
        }
    }

    void resetSelectors()
    {
        heroSelector = Hero.Null;
        actionSelector = Action.Null;
    }

    Direction getDirection()
    {
        if (Input.GetButtonUp("Down"))
            return Direction.DOWN;
        else if (Input.GetButtonUp("Right"))
            return Direction.RIGHT;
        else if (Input.GetButtonUp("Left"))
            return Direction.LEFT;
        else if (Input.GetButtonUp("Up"))
            return Direction.UP;
        else if (Input.GetButtonUp("Deselect"))
            return Direction.DESELECT;
        else
            return Direction.NONE;
    }

    void Test(Text text)
    {
        if (heroSelector == Hero.Aria)
            hero0Action(text);
        else if (heroSelector == Hero.Bayl)
            hero1Action(text);
        else if (heroSelector == Hero.Xaine)
            hero2Action(text);
        else if (heroSelector == Hero.Yazir)
            hero3Action(text);
        else return;
    }

    void hero0Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            AriaObject.GetComponent<AriaScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            AriaObject.GetComponent<AriaScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            AriaObject.GetComponent<AriaScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            AriaObject.GetComponent<AriaScript>().Special(text);
        }
        resetSelectors();
    }

    void hero1Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            BaylObject.GetComponent<BaylScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            BaylObject.GetComponent<BaylScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            BaylObject.GetComponent<BaylScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            BaylObject.GetComponent<BaylScript>().Special(text);
        }
        resetSelectors();
    }

    void hero2Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            XaineObject.GetComponent<XaineScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            XaineObject.GetComponent<XaineScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            XaineObject.GetComponent<XaineScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            XaineObject.GetComponent<XaineScript>().Special(text);
        }
        resetSelectors();
    }

    void hero3Action(Text text)
    {
        if (actionSelector == Action.Null)
            return;
        else if (actionSelector == Action.Utility)
        {
            YazirObject.GetComponent<YazirScript>().Utility(text);
        }
        else if (actionSelector == Action.Ultimate)
        {
            YazirObject.GetComponent<YazirScript>().Ultimate(text);
        }
        else if (actionSelector == Action.Normal)
        {
            YazirObject.GetComponent<YazirScript>().Normal(text);
        }
        else if (actionSelector == Action.Special)
        {
            YazirObject.GetComponent<YazirScript>().Special(text);
        }
        resetSelectors();
    }

    public void attackPlayer(EnemyAttack attack)
    {
        for (int i = 0; i < attack.targetNumber; ++i)
        {
            attackTarget(attack.targets[i], attack);
        }
    }

    public void attackPlayerWithDelay(EnemyAttack attack)
    {
        float delay = 0.5f;
        float start = Time.time;
        int counter = 0;
        while(true)
        {
            if (counter == attack.targetNumber)
                break;
            if (Time.time - start > delay)
            {
                start = Time.time;
                attackTarget(attack.targets[counter], attack);
                ++counter;
            }
        }
    }

    void attackTarget(Target target, EnemyAttack attack)
    {
        switch(target)
        {
            case Target.Aria:
                AriaObject.GetComponent<AriaScript>().takeDamage(attack.phDamage, attack.maDamage);
                AriaObject.GetComponent<AriaScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            case Target.Bayl:
                BaylObject.GetComponent<BaylScript>().takeDamage(attack.phDamage, attack.maDamage);
                BaylObject.GetComponent<BaylScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            case Target.Xaine:
                XaineObject.GetComponent<XaineScript>().takeDamage(attack.phDamage, attack.maDamage);
                XaineObject.GetComponent<XaineScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            case Target.Yazir:
                YazirObject.GetComponent<YazirScript>().takeDamage(attack.phDamage, attack.maDamage);
                YazirObject.GetComponent<YazirScript>().statusEffect(attack.ailment, attack.ailChance);
                return;
            default:
                return;
        }
    }

    public void killAll()
    {
        AriaObject.GetComponent<AriaScript>().kill();
        BaylObject.GetComponent<BaylScript>().kill();
        XaineObject.GetComponent<XaineScript>().kill();
        YazirObject.GetComponent<YazirScript>().kill();
    }

    public void heal()
    {
        AriaObject.GetComponent<AriaScript>().heal();
        BaylObject.GetComponent<BaylScript>().heal();
        XaineObject.GetComponent<XaineScript>().heal();
        YazirObject.GetComponent<YazirScript>().heal();
    }

    public void raiseSpeed()
    {
        float amount = 20f;
        AriaObject.GetComponent<AriaScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
        BaylObject.GetComponent<BaylScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
        XaineObject.GetComponent<XaineScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
        YazirObject.GetComponent<YazirScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.Speed, amount);
    }

    public void raiseStrength()
    {
        float amount = 20f;
        AriaObject.GetComponent<AriaScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
        BaylObject.GetComponent<BaylScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
        XaineObject.GetComponent<XaineScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
        YazirObject.GetComponent<YazirScript>().getHeroClass().getDamageModule().raiseAttribute(Attribute.PhysicalAttack, amount);
    }

    public void restoreSpeed()
    {
        AriaObject.GetComponent<AriaScript>().getHeroClass().restoreSpeed();
        BaylObject.GetComponent<BaylScript>().getHeroClass().restoreSpeed();
        XaineObject.GetComponent<XaineScript>().getHeroClass().restoreSpeed();
        YazirObject.GetComponent<YazirScript>().getHeroClass().restoreSpeed();
    }

    public void restoreStrength()
    {
        AriaObject.GetComponent<AriaScript>().getHeroClass().restoreStrength();
        BaylObject.GetComponent<BaylScript>().getHeroClass().restoreStrength();
        XaineObject.GetComponent<XaineScript>().getHeroClass().restoreStrength();
        YazirObject.GetComponent<YazirScript>().getHeroClass().restoreStrength();
    }

    public Vector2 getCenterPosition()
    {
        return centerPosition;
    }

    public void hastingWind(GameObject prefab)
    {
        Vector3 ariaPosition = getIconPosition(AriaObject.GetComponent<AriaScript>().getHeroClass().getPosition());
        Vector3 baylPosition = getIconPosition(BaylObject.GetComponent<BaylScript>().getHeroClass().getPosition());
        Vector3 xainePosition = getIconPosition(XaineObject.GetComponent<XaineScript>().getHeroClass().getPosition());
        Vector3 yazirPosition = getIconPosition(YazirObject.GetComponent<YazirScript>().getHeroClass().getPosition());
        AriaHaste = Instantiate(prefab, ariaPosition, Quaternion.identity);
        BaylHaste = Instantiate(prefab, baylPosition, Quaternion.identity);
        XaineHaste = Instantiate(prefab, xainePosition, Quaternion.identity);
        YazirHaste = Instantiate(prefab, yazirPosition, Quaternion.identity);

    }

    Vector3 getIconPosition(Vector2 heroPosition)
    {
        Vector3 position;
        position.x = heroPosition.x + 1;
        position.y = heroPosition.y + 1;
        position.z = -1;
        return position;
    }

    public void destroyHastingWind()
    {
        Destroy(AriaHaste);
        Destroy(BaylHaste);
        Destroy(XaineHaste);
        Destroy(YazirHaste);
    }
}