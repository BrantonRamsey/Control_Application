#include <Servo.h>

int servoCount = 7;
int servoPins[] = {2, 3, 4, 5, 6, 7, 8};
Servo servos[7];

void setup() 
{
  Serial.begin(9600);
  AttachServos();
//  AttachServosMirror();=3
  
}

void loop() 
{
  
}

void serialEvent() 
{
  int channel;
  int pos;
  
  channel = Serial.readStringUntil(':').toInt();
  pos = Serial.readStringUntil('*').toInt();
  servos[channel].write(pos);
//  delay(100);
}

void AttachServos() 
{
  for(int i = 0; i < servoCount; i ++) 
  {
    servos[i].attach(servoPins[i]);
//    delay(100);
  }

}



//void AttachServosMirror()
//{
//  for(int i = 0; i < servoCount; i --) 
//  {
//    servos[1].attach(servoPins[1]);
////    delay(100);
//  }
//}
