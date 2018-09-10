import unittest
import algorithms
import peak


class Algo1Tests(unittest.TestCase):

    def runPeak(self, grid, size, expected_value, expected_location):

        (width, height) = size

        problem = peak.PeakProblem(grid, (0, 0, width, height))

        peek_location = algorithms.algorithm1(problem)

        is_peak = problem.isPeak(peek_location)

        self.assertEqual(True, is_peak)
        self.assertEqual(expected_value, problem.get(peek_location))
        self.assertEqual(expected_location, peek_location)

    def test_001(self):
        """
        Should return only value given 1 x 1 grid.
        """
        grid = [
            [1]
        ]
        size = (1, 1)
        expected_value = 1
        expected_location = (0, 0)
        self.runPeak(grid, size, expected_value, expected_location)

    def test_002(self):
        """
        Should return only value given 2 x 1 and 1 x 2 grid.
        """
        grid = [
            [2, 2]
        ]
        size = (1, 2)
        expected_value = 2
        expected_location = (0, 1)
        self.runPeak(grid, size, expected_value, expected_location)

        grid = [
            [2],
            [2]
        ]
        size = (2, 1)
        expected_value = 2
        expected_location = (0, 0)
        self.runPeak(grid, size, expected_value, expected_location)
