# ballOnBeamSimulator
유니티로 만든 창연공 시뮬레이터입니다.

위치가 정해지지 않은 서보 기둥과 레일의 위치를 옮겨가며 적당한 위치를 찾을 수 있습니다.

PID 값에 따른 PID 제어를 시뮬레이션 해볼 수 있습니다.

조작법

위, 아래 방향키: 

서보 모터 위, 아래로 돌림(PID 중에는 사용 불가)

좌, 우 방향키: 

공 좌, 우로 굴림(PID중 사용 가능)

A 입력칸: 

왼쪽 벽과 레일 사이의 거리 입력(단위: cm), Apply 버튼 눌러서 적용

B 입력칸: 

왼쪽 벽과 서보 기둥 사이의 거리 입력(단위: cm), Apply 버튼 눌러서 적용

A, B, C 버튼: 

타겟 위치를 A(255mm), B(155mm), C(55mm)로 변경, (PID 실행 중에도 변경 가능)

targetDist 입력칸: 

타겟 거리 입력(단위: mm)

currentDist:

공과 센서의 사이의 현재 거리 실시간으로 보여줌(단위: mm)

P, I, D 입력칸: 

PID 제어에 사용할 P,I,D값 입력, Apply 버튼 눌러서 적용

pterm, dterm, iterm: 

PID 실행 중 pterm, dterm, iterm 값을 실시간으로 보여줌

Apply 버튼: 

A, B, targetDist, P, I, D 입력칸에 입력한 값 적용하면서 시뮬레이터를 다시 시작함

control: 

PID ON

-control 값을 실시간으로 보여줌, 500 ~ 2500을 벗어날 수 있지만 그렇다고 서보가 거기까지 돌아가진 않음

PID OFF

-현재 각도를 -90도 ~ 90도를 사용하여 실시간으로 보여줌, 저 범위 밖으로 벗어나지 않음

PID ON/OFF 버튼: 

PID 기능을 키거나 끔, 처음 시작할 땐 꺼진 상태로 시작함


일시정지:

스페이스바


사용한 외부 에셋:

Fantasy Skybox FREE
