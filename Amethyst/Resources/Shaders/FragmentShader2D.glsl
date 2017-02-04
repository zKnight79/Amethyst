#version 330

in vec4 color;
in vec2 texCoord;

out vec4 fragColor;

uniform sampler2D texSampler;

void main()
{
    fragColor = color*texture(texSampler, texCoord);
}
