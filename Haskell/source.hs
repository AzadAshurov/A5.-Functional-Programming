removeNumbers :: [Int] -> Int -> [Int]
removeNumbers xs step
    | step `mod` 3 == 0 = [x | (i,x) <- zip [1..] xs, odd i]
    | step `mod` 3 == 1 = [x | (i,x) <- zip [1..] xs, even i]
    | otherwise         = [x | (i,x) <- zip [1..] xs, i `mod` 3 /= 0]

arrayDevide :: [Int] -> Int -> Int
arrayDevide [x] _ = x
arrayDevide xs step = arrayDevide (removeNumbers xs step) (step + 1)

main :: IO ()
main = do
    n <- readLn
    print (arrayDevide [1..n] 0)