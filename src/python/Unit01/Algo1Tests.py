import unittest
import algorithms
import peak


class AlgoTests(unittest.TestCase):

    def runPeak(self, grid, size, expected_location, expected_value):

        (width, height) = size

        problem = peak.PeakProblem(grid, (0, 0, width, height))

        peek_location = algorithms.algorithm1(problem)

        is_peak = problem.isPeak(peek_location)

        self.assertEqual(True, is_peak)
        self.assertEqual(expected_location, peek_location)
        self.assertEqual(expected_value, problem.get(peek_location))

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
        self.runPeak(grid, size, expected_location, expected_value)

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
        self.runPeak(grid, size, expected_location, expected_value)

        grid = [
            [2],
            [2]
        ]
        size = (2, 1)
        expected_value = 2
        expected_location = (0, 0)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_003(self):
        """
        Should return larger value given 2 x 1 and 1 x 2 grid.
        """
        grid = [
            [0, 1]
        ]
        size = (1, 2)
        expected_value = 1
        expected_location = (0, 1)
        self.runPeak(grid, size, expected_location, expected_value)

        grid = [
            [1, 0]
        ]
        size = (1, 2)
        expected_value = 1
        expected_location = (0, 0)
        self.runPeak(grid, size, expected_location, expected_value)

        grid = [
            [0],
            [1]
        ]
        size = (2, 1)
        expected_value = 1
        expected_location = (1, 0)
        self.runPeak(grid, size, expected_location, expected_value)

        grid = [
            [1],
            [0]
        ]
        size = (2, 1)
        expected_value = 1
        expected_location = (0, 0)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_010(self):
        """
        Should return only value given 2 x 2 grid with all the same value.
        """
        grid = [
            [2, 2],
            [2, 2]
        ]
        size = (2, 2)
        expected_value = 2
        expected_location = (0, 1)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_012(self):
        """
        Should return only value given 3 x 3 grid with all the same values.
        """
        grid = [
            [2, 2, 2],
            [2, 2, 2],
            [2, 2, 2]
        ]
        size = (3, 3)
        expected_value = 2
        expected_location = (0, 1)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_013(self):
        """
        Should find peak when in center of 3 x 3 grid.
        """
        grid = [
            [0, 1, 0],
            [1, 2, 1],
            [0, 1, 0]
        ]
        size = (3, 3)
        expected_value = 2
        expected_location = (1, 1)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_014(self):
        """
        Should find peak when in x = 0, y = 0 of 3 x 3 grid.
        """
        grid = [
            [4, 3, 1],
            [3, 2, 1],
            [1, 1, 0]
        ]
        size = (3, 3)
        expected_value = 4
        expected_location = (0, 0)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_015(self):
        """
        Should find peak when in x = 1, y = 0 of 3 x 3 grid.
        """
        grid = [
            [3, 4, 1],
            [3, 2, 1],
            [1, 1, 0]
        ]
        size = (3, 3)
        expected_value = 4
        expected_location = (0, 1)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_016(self):
        """
        Should find peak when in x = 2, y = 0 of 3 x 3 grid.
        """
        grid = [
            [1, 3, 4],
            [1, 2, 3],
            [0, 1, 1]
        ]
        size = (3, 3)
        expected_value = 4
        expected_location = (0, 2)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_017(self):
        """
        Should find peak when in x = 2, y = 0 of 3 x 3 grid.
        """
        grid = [
            [0, 1, 1],
            [1, 2, 3],
            [1, 3, 4],
        ]
        size = (3, 3)
        expected_value = 4
        expected_location = (2, 2)
        self.runPeak(grid, size, expected_location, expected_value)

    def test_018(self):
        grid = [
            [4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2],
            [5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3],
            [6, 7, 8, 9, 10, 9, 8, 7, 6, 5, 4],
            [7, 8, 9, 10, 11, 10, 9, 8, 7, 6, 5],
            [8, 9, 10, 11, 12, 11, 10, 9, 8, 7, 6],
            [7, 8, 9, 10, 11, 10, 9, 8, 7, 6, 5],
            [6, 7, 8, 9, 10, 9, 8, 7, 6, 5, 4],
            [5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3],
            [4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2],
            [3, 4, 5, 6, 7, 6, 5, 4, 3, 2, 1],
            [2, 3, 4, 5, 6, 5, 4, 3, 2, 1, 0],
        ]
        size = (11, 11)
        expected_value = 12
        expected_location = (4, 4)
        self.runPeak(grid, size, expected_location, expected_value)
