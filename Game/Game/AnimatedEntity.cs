using SFML.System;

namespace Game; 

class AnimatedEntity : Entity
{
    private Dictionary<string, AnimationData> animations =new Dictionary<string, AnimationData>();
    private Vector2i frameSize;
    private float frameTimer;
    
    public AnimatedEntity(string imageFilePath) : base(imageFilePath)
    {
        
    }

    public override void Update(float deltaTime)
    {
        
    }
}
