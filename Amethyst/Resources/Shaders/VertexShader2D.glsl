#version 330

in vec2 vertexPosition;
in vec4 vertexColor;
in vec2 vertexTexCoord;

out vec4 color;
out vec2 texCoord;

uniform mat4 MVP;

void main()
{
    color = vertexColor;
	texCoord = vertexTexCoord;
    gl_Position = MVP * vec4(vertexPosition, 0, 1);
}
