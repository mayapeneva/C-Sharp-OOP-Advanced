public interface ITarget
{
    int Health { get; set; }
    int Experience { get; set; }

    void TakeAttack(int attackPoints);

    int GiveExperience();

    bool IsDead();
}