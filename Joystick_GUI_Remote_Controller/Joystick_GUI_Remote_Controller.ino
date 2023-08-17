const int VERTICALMOVE_PIN = A0;    // 수직 이동 핀
const int HORIZONTALMOVE_PIN = A1;  // 수평 이동 핀
const int VERTICALAIM_PIN = A2;     // 수직 에임 핀
const int HORIZONTALAIM_PIN = A3;   // 수평 에임 핀

const String MOVE_KEYS[] = { "W", "S", "D", "A" };
const String AIM_KEYS[] = { "UP", "DOWN", "RIGHT", "LEFT" };
int AIM_SENSITIVITY = 10;

void setup() {
  pinMode(VERTICALMOVE_PIN, INPUT);    // 수직 이동
  pinMode(HORIZONTALMOVE_PIN, INPUT);  // 수평 이동
  pinMode(VERTICALAIM_PIN, INPUT);     // 수직 에임
  pinMode(HORIZONTALAIM_PIN, INPUT);   // 수평 에임

  Serial.begin(115200UL);
}

void loop() {
  String moveDirectionVertical = "";
  String moveDirectionHorizontal = "";
  String aimOffsetX = "";
  String aimOffsetY = "";

  int vmove = map(analogRead(VERTICALMOVE_PIN), 0, 1023, 0, 100);
  int hmove = map(analogRead(HORIZONTALMOVE_PIN), 0, 1023, 0, 100);
  int vaim = map(analogRead(VERTICALAIM_PIN), 0, 1023, 0, 100);
  int haim = map(analogRead(HORIZONTALAIM_PIN), 0, 1023, 0, 100);

  /*Serial.println(vmove+ hmove+ vaim+ haim);
  Serial.print("vmove: "+String(vmove)+",");
  Serial.print("hmove: "+String(hmove)+",");
  Serial.print("vaim"+String(vaim)+",");
  Serial.println("haim"+String(haim));*/


  if (Serial.available()) {
    String str_command = Serial.readString();  // AIM_SENSITIVITY의 새로운 값
    str_command.trim();                        // \n 삭제
    if (str_command.toInt() > 0 || str_command.toInt() < 101)
      AIM_SENSITIVITY = str_command.toInt();
  }

  if (vmove > 59) {
    moveDirectionVertical += MOVE_KEYS[0];  // W
  } else if (vmove < 41) {
    moveDirectionVertical += MOVE_KEYS[1];  // S
  }

  if (hmove > 59) {
    moveDirectionHorizontal += MOVE_KEYS[2];  // D
  } else if (hmove < 41) {
    moveDirectionHorizontal += MOVE_KEYS[3];  // A
  }

  if (vaim > 59) {
    aimOffsetY += AIM_KEYS[0]; // UP
  } else if (vaim < 41) {
    aimOffsetY += AIM_KEYS[1]; // DOWN
  }

  if (haim > 59) {
    aimOffsetX += AIM_KEYS[2]; // RIGHT
  } else if (haim < 41) {
    aimOffsetX += AIM_KEYS[3]; // LEFT
  }

  Serial.println(moveDirectionVertical + "," + moveDirectionHorizontal + "," + aimOffsetX + "," + aimOffsetY + "," + String(AIM_SENSITIVITY));
  delay(300UL);
}
