% sekcja 12, by Miłosz Gilga
clc
clear

AVG = 10; % wartość średnia
SIGMA = 2; % odchylenie średniokwadratowe    
N = 104; % liczebność zbioru danych
K = 4; % liczba klas (1-4)

% kolory poszczególnych klas zapisane w formacie HEX
C = { '#fc7703' '#1ab81f' '#c42b1a' '#861ac4' };

rVx = randn(1, N*K); % generacja losowych wartości X
rVy = randn(1, N*K); % generacja losowych wartości Y

xMult = [ 1 -1 -1 1 ]; % multiplikator wartości X
yMult = [ 1 1 -1 -1 ]; % multiplikator wartości Y

rVx = multiply(rVx, xMult, N, K, AVG, SIGMA);
rVy = multiply(rVy, yMult, N, K, AVG, SIGMA);

scatter(rVx, rVy, 40, genColor(K, N, C), 'linewidth', 1.2);
title([ 'N = ', num2str(N), ' AVG = ', num2str(AVG), ' SIGMA = ', num2str(SIGMA) ]);

box on
grid on

Z = [ rVx; rVy ];
D = genDiag(N, K, 1);

% funkcja modyfikująca wartości losowe na podstawie tablicy multiplikatorów
% i przekazywanych parametrów
function retArr = multiply(rndArr, multArr, N, K, AVG, S)
    retArr = zeros(size(rndArr));
    j = 1;
    for i=1:1:N*K
        retArr(i) = rndArr(i)*S + (AVG*multArr(j));
        if mod(i, N) == 0
            j = j+1;
        end
    end
end

% funkcja generująca wektor kolorów wykresu na podstawie liczby klas i
% podstawowych wartości przekazanych w tablicy cArr
function retColor = genColor(K, N, cArr)
    retColor = zeros(K*N,3);
    j = 1;
    for i=1:1:K*N
        hexStr = char(cArr(j));
        n = 2;
        for m=1:1:3
            retColor(i,m) = double(hex2dec(hexStr(n:n+1)))/255;
            n = n+2;
        end
        if mod(i, N) == 0
            j = j+1;
        end
    end
end

% funkcja generująca macierz diagonalną N*KxK z wartością D na diagonalnej
function retDiag = genDiag(N, K, D)
    retDiag = zeros(K, K*N);
    for i=1:1:K
        for j=1:1:K*N
            if j < i*N+1 && j > (i-1)*N
                retDiag(i,j) = D;
            end
        end
    end
end
