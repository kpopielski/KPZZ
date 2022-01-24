#include <math.h>


int trigPinRight = 7;  //tigg1
int echoPinRight = 8;  //echo1
int trigPinLeft = 9;  //tigg1
int echoPinLeft = 10;  //echo1
long durationR,durationL, distanceR, distanceL; 
double fraction;
int readcount=0;

void setup() {
  
  Serial.begin(9600);
  pinMode(trigPinRight, OUTPUT);
  pinMode(echoPinRight, INPUT);
   pinMode(trigPinLeft, OUTPUT);
  pinMode(echoPinLeft, INPUT);
}

void loop() {
  DistancecalL();
  readcount=0;
  delay(100);
  DistancecalR();
  readcount=0;
  delay(100);
}
void DistancecalL(){
  
  digitalWrite(trigPinLeft, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPinLeft, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPinLeft, LOW);
  pinMode(echoPinLeft, INPUT);
  durationL = pulseIn(echoPinLeft, HIGH);
  distanceL=durationL*0.034/2;
  Serial.print("L");
  Serial.print(distanceL);
  Serial.println("a");
}

void DistancecalR(){
  digitalWrite(trigPinRight, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPinRight, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPinRight, LOW);
  pinMode(echoPinRight, INPUT);
  durationR = pulseIn(echoPinRight, HIGH);
  distanceR=durationR*0.034/2;
  Serial.print("R");
  Serial.print(distanceR);
  Serial.println("b");
 
}
